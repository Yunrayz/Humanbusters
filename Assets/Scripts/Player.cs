using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveDirection;

    public int hp;
    private bool timeIsPassed;

    public bool canMove = true;


    private void Start()
    {
        timeIsPassed = true;
    }

    void Update()
    {
        ProcessInputs();
         if(canMove)
            Move();
        else
            StopMovement();
        
        
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
        rb.velocity = new Vector2(0, 0);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exorcist" && timeIsPassed)
        {
            Debug.Log("CollisionDetected");
            hp -= 100;
            timeIsPassed = false;
            StartCoroutine(Waiting());
        }
        
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        timeIsPassed = true;
    }

}
