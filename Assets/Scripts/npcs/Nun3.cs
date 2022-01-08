using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nun3 : MonoBehaviour
{
    public float speed;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private int walkingStop;
    private Vector2 obj;


    private Rigidbody2D nunRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;
    private GameManager gameManager;

    void Start()
    {
        nunRb = GetComponent<Rigidbody2D>();
        audioSource = transform.GetComponent<AudioSource>();
        fear = 0;
        fearLimit = 40;
        functionsScript = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        running = false;
        speed = 1;
        walkingStop = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        else if (!gameManager.pause)
        {
            Move();
            if (functionsScript.actionTriggered)
            {
                fear += functionsScript.getScared(transform.position, functionsScript.posAction);
            }
        }

    }

    private void Move()
    {

        if (walkingStop == 0)
        {
            obj = new Vector2(18.45f, -2.2f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 1;
            }
        }
        else
        {
            obj = new Vector2(27.5f, -2.2f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 0;
            }
        }

    }

    private void RunAway()
    {
        if (!running)
            obj = new Vector2(23f, -2.2f);

        running = true;
        speed = 2.5f;

        transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, obj) < 0.01f || transform.position.y < 0.5)
        {
            obj = new Vector2(23f, -2.7f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
