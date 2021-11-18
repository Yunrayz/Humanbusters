using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    public float speed = 1.5f;
    private int fear;
    private Rigidbody2D neighborRb;
    private Vector2 direction = Vector2.down;

    // Start is called before the first frame update
    void Start()
    {
        neighborRb = GetComponent<Rigidbody2D>();
        fear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 0)
        {
            direction = Vector2.down;
            neighborRb.velocity = speed * direction;
        } else if (transform.position.y <=-2.5)
        {
            direction = Vector2.up;
            neighborRb.velocity = speed * direction;
        } else
        {
            neighborRb.velocity = speed * direction;
        }
    }
}
