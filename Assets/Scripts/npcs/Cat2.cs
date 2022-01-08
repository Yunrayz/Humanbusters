using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat2 : MonoBehaviour
{
    public float speed;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 50;      //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private Vector2 obj;
    private int walkingStop;
    int runningStop;

    private Rigidbody2D neighborRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        neighborRb = GetComponent<Rigidbody2D>();
        fear = 0;
        fearLimit = 50;
        functionsScript = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        audioSource = GetComponent<AudioSource>();
        running = false;
        speed = 3f;
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fear >= fearLimit * 0.75)
            speed = 5;

        if (fear >= fearLimit)
        {
            if (!running)
                audioSource.Play();
            RunAway();
        }
        else if (player.hp <= 0)
        {
            functionsScript.stopMovement(neighborRb);
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
            obj = new Vector2(20.45f, -11.5f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 1;
        }
        else
        {
            obj = new Vector2(20.45f, -14.5f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
                walkingStop = 0;
        }

    }


    private void RunAway()
    {
        if (!running)
            obj = new Vector2(20.45f, -15f);

        running = true;
        speed = 2.5f;
        transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, obj) < 0.01f)
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
