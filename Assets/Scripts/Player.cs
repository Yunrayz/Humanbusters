using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Vector2 moveDirection;

    public int hp;
    private bool timeIsPassed;
    private bool timeIsPassedCop;
    private GameManager gameManager;

    public bool canMove = true;

    private Man1 man;


    private void Start()
    {
        hp = 100;
        timeIsPassed = true;
        timeIsPassedCop = true;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        man = GameObject.Find("Man1").GetComponent<Man1>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    void Update()
    {
        if (gameManager.pause)
        {
            StopMovement();
        }

        ProcessInputs();
        if (hp <= 0)
        {
            canMove = false;
            StopMovement();
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
        else if (canMove && !gameManager.pause)
            Move();
        else
            StopMovement();


        if(!man.running && man.fear >= man.fearLimit){
            GetComponent<AudioSource>().Play();
        }
        
    }
    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exorcist" && timeIsPassed && !gameManager.pause)
        {
            hp -= 5;
            timeIsPassed = false;
            StartCoroutine(Waiting());
        } 
        if (collision.gameObject.tag == "Cop" && timeIsPassedCop && !gameManager.pause)
        {
            hp -= 10;
            timeIsPassedCop = false;
            StartCoroutine(WaitingCop());

        }
        
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        timeIsPassed = true;
    }
    IEnumerator WaitingCop()
    {
        yield return new WaitForSeconds(1f);
        timeIsPassedCop = true;
    }
}
