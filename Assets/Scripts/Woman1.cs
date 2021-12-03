using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman1 : MonoBehaviour
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

    private Rigidbody2D neighborRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        neighborRb = GetComponent<Rigidbody2D>();
        fear = 0;
        functionsScript = GameObject.Find("GameManager").GetComponent<NPCFunctions>();
        audioSource = GetComponent<AudioSource>();
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
            }
        }

        if (fear >= fearLimit)
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

        if (transform.position.x <= 3)
        {
            direction = Vector2.right;
            neighborRb.velocity = speed * direction;
        }
        else if (transform.position.x >= 4.5)
        {
            direction = Vector2.left;
            neighborRb.velocity = speed * direction;
        }
        else
        {
            neighborRb.velocity = speed * direction;
        }
    }


    private void RunAway()
    {
        running = true;
        speed = 2.5f;
        

        switch (stop)
        {
            case 0:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1.5f, -3), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(1.5f, -3)) < 0.001f)
                    stop = 1;
                break;
            case 1:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5.5f, -3), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(-5.5f, -3)) < 0.001f)
                    stop = 2;
                break;
            case 2:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5.5f, 1), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(-5.5f, 1)) < 0.001f)
                    Destroy(this.gameObject);
                break;
        }
    }
}
