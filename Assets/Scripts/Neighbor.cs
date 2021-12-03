using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{

    public float speed = 1.5f;
    public int fear;
    private Rigidbody2D neighbor;
    public Vector2 direction = Vector2.down;

    // Start is called before the first frame update
    void Start()
    {
        neighbor = GetComponent<Rigidbody2D>();
        fear = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y >= 0)
        {
            direction = Vector2.down;
            neighbor.velocity = speed * direction;
        } else if (transform.position.y <= -2.5) {
            direction = Vector2.up;
            neighbor.velocity = speed * direction;
        } else
        {
            neighbor.velocity = speed * direction;
        }

        /* if (bool){
         * calculate distance (la accion debe ser localizada y esta coor compartida)
         * if(distance<algo){
         * waiting;
         * fear += algo;
         * }} */
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
    }
}
