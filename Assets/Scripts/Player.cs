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

    public bool canMove = true;

    private Man1 man;


    private void Start()
    {
        timeIsPassed = true;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        man = GameObject.Find("Man1").GetComponent<Man1>();

    }

    void Update()
    {
        ProcessInputs();
        if (hp <= 0)
        {
            canMove = false;
            StopMovement();
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
        else if (canMove)
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
        if (collision.gameObject.tag == "Exorcist" && timeIsPassed)
        {
            hp -= 8;
            timeIsPassed = false;
            StartCoroutine(Waiting());
        }
        
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        timeIsPassed = true;
    }

}
