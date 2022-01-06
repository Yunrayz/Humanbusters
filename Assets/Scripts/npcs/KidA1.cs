using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidA1 : MonoBehaviour
{
    public float speed = 1.5f;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    public bool running;
    private Vector2 obj;
    private int walkingStop;

    //get from interaction scripts

    private Rigidbody2D kidARb;
    private Vector2 direction = Vector2.down;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;


    void Start()
    {
        fear = 0;
        fearLimit = 30;
        kidARb = GetComponent<Rigidbody2D>();
        functionsScript = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        audioSource = GetComponent<AudioSource>();
        running = false;
        player = GameObject.Find("Player").GetComponent<Player>();
    }


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
        else if (player.hp <= 0)
        {
            functionsScript.stopMovement(kidARb);
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
            obj = new Vector2(26.5f, -15f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 1;
        }
        else if (walkingStop == 1)
        {
            obj = new Vector2(26.5f, -12f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 2;
        }
        else if (walkingStop == 2)
        {
            obj = new Vector2(26.5f, -15f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 3;
        }
        else
        {
            obj = new Vector2(18, -15f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 0;
        }

    }


    private void RunAway()
    {
        if (!running)
            obj = new Vector2(26.4f, -15f);

        running = true;
        speed = 2.5f;
        transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, obj) < 0.01f )
        {
            obj = new Vector2(26.4f, -17f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                Destroy(this.gameObject);
                Destroy(GameObject.Find("Man fearbar"));
            }
        }

    }
}
