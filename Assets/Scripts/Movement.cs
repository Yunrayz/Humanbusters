using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove = true;
    public Rigidbody2D rb;
    public Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();
        if(canMove){
            Move();
        }
        else{
            rb.velocity = Vector2.zero;
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
}
