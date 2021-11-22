using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveDirection;

    public float hp;
    private bool timeIsPassed;


    private void Start()
    {
        timeIsPassed = true;
    }

    void Update()
    {
        
        if (transform.position.x > -6.7 && transform.position.x < 6.5 && 
            transform.position.y < 4.55 && transform.position.y > -4.55)
        {
            ProcessInputs();
            Move();
        } else
        {
            stopAtBoundary();
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
        rb.velocity = new Vector2(0, 0);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exorcist" && timeIsPassed)
        {
            Debug.Log("CollisionDetected");
            //hp =- 111
            timeIsPassed = false;
            StartCoroutine(Waiting());
        }
        
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        timeIsPassed = true;
    }

    private void stopAtBoundary()
    {
        rb.velocity = new Vector2(0, 0);
        if (transform.position.x <= -6.7)
        {
            rb.AddForce(Vector2.right);
        }
        else if (transform.position.x >= 6.5)
        {
            rb.AddForce(Vector2.left);
        }
        else if (transform.position.y >= 4.55)
        {
            rb.AddForce(Vector2.down);
        }
        else if (transform.position.y <= -4.55)
        {
            rb.AddForce(Vector2.up);
        }
    }
}
