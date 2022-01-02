using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nun1 : MonoBehaviour
{
    public float speed = 1.5f;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private Player player;
    private int walkingStop;
    private Vector2 obj;


    private Rigidbody2D nunRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;

    void Start()
    {
        fear = 0;
        nunRb = GetComponent<Rigidbody2D>();
        audioSource = transform.GetComponent<AudioSource>();
        functionsScript = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        running = false;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fear >= fearLimit * 0.75)
            speed = 2;

        if (fear >= fearLimit)
        {
            if (!running)
                audioSource.Play();
            RunAway();
        }
        else if (functionsScript.actionTriggered)
        {
            fear += functionsScript.getScared(transform.position, functionsScript.posAction, radius);
        }
        else if (player.hp <= 0)
        {
            functionsScript.stopMovement(nunRb);
        }
        else
        {
            Move();
        }

    }

    private void Move()
    {
        
        if (walkingStop == 0)
        {
            obj = new Vector2(26, 0.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 1;
        }
        else
        {
            obj = new Vector2(18, 0.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 0;
        }
    }

    private void RunAway()
    {
        if (!running)
            obj = new Vector2(23f, 0.75f);

        running = true;
        speed = 2.8f;

        transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, obj) < 0.01f || transform.position.y < 0.75)
        {
            obj = new Vector2(23f, -2.6f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                Destroy(this.gameObject);
                //Destroy(GameObject.Find("Nun fearbar"));
            }
        }

    }
}
