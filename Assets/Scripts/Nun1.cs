using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nun1 : MonoBehaviour
{
    public float speed;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private int stop;


    //get from interaction scripts
    public bool actionTriggered = false;
    public float xPosAction = 5;
    public float yPosAction = 5;


    private Rigidbody2D nunRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;

    void Start()
    {
        nunRb = GetComponent<Rigidbody2D>();
        audioSource = transform.GetComponent<AudioSource>();
        fear = 0;
        functionsScript = GameObject.Find("GameManager").GetComponent<NPCFunctions>();
        running = false;
        speed = 1;
        stop = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (actionTriggered)
        {
            if (functionsScript.checkDistance(xPosAction, yPosAction, radius))
            {
                fear += 100;
                audioSource.Play();
            }
        }

        if (fear > fearLimit)
        {
            if (!running)
                audioSource.Play();
            RunAway();
        }
        else
        {
            Move();
        }

    }

    private void Move()
    {
        if (transform.position.x >= 6)
        {
            direction = Vector2.left;
            nunRb.velocity = speed * direction;
        }
        else if (transform.position.x <= 3)
        {
            direction = Vector2.right;
            nunRb.velocity = speed * direction;
        }
        else
        {
            nunRb.velocity = speed * direction;
        }
    }

    private void RunAway()
    {
        running = true;
        speed = 2.5f;

        switch (stop)
        {
            case 0:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(5.5f, -3), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(5.5f, -3)) < 0.001f)
                    stop = 1;
                break;
            case 1:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(5.5f, 1.8f), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(5.5f, 1.8f)) < 0.001f)
                    Destroy(this.gameObject);
                break;
        }
    }
}
