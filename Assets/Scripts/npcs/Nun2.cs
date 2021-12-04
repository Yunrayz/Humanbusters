using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nun2 : MonoBehaviour
{
    public float speed;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private int stop;
    private int walkingStop;
    private Vector2 obj;


    private Rigidbody2D nunRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;

    void Start()
    {
        nunRb = GetComponent<Rigidbody2D>();
        audioSource = transform.GetComponent<AudioSource>();
        fear = 0;
        functionsScript = GameObject.Find("GameManager").GetComponent<NPCFunctions>();
        running = false;
        speed = 1;
        stop = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fear >= fearLimit * 0.75)
            speed = 2;

        if (fear > fearLimit)
        {
            if (!running)
                audioSource.Play();
            RunAway();
        }
        else if (player.hp <= 0)
        {
            functionsScript.stopMovement(nunRb);
        }
        else
        {
            Move(); 
            if (functionsScript.actionTriggered)
            {
                fear += functionsScript.getScared(transform.position, functionsScript.posAction, radius);
            }
        }

    }

    private void Move()
    {
        
        if (walkingStop == 0)
        {
            obj = new Vector2(-4.5f, -16f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 1;
        }
        else if (walkingStop == 1)
        {
            obj = new Vector2(-4.5f, -12f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 2;
        }
        else if (walkingStop == 2)
        {
            obj = new Vector2(-4.5f, -16f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 3;
        }
        else
        {
            obj = new Vector2(5f, -16f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 0;
        }
        
    }

    private void RunAway()
    {
        if (!running)
            obj = new Vector2(-4.5f, -16);

        running = true;
        speed = 2.8f;

        transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, obj) < 0.01f || transform.position.y > -16)
        {
            obj = new Vector2(-5.5f, -11f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                Destroy(this.gameObject);
                //Destroy(GameObject.Find("Nun fearbar"));
            }
        }


    }
}
