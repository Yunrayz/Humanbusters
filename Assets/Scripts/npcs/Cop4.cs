using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop4 : MonoBehaviour
{
    public float speed;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;
    private int walkingStop;
    private Vector2 obj;


    private Rigidbody2D copRb;
    private Vector2 direction = Vector2.left;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;
    private Animator animator;
    private GameObject squareR;
    private GameObject squareL;
    private GameManager gameManager;


    void Start()
    {
        copRb = GetComponent<Rigidbody2D>();
        animator = transform.Find("Cop1").GetComponent<Animator>();
        squareR = transform.Find("SquareR").gameObject;
        squareL = transform.Find("SquareL").gameObject;
        squareR.SetActive(false);
        audioSource = transform.GetComponent<AudioSource>();
        fear = 0;
        fearLimit = 70;
        functionsScript = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        running = false;
        speed = 1;
        walkingStop = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


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
            functionsScript.stopMovement(copRb);
        }
        else if (!gameManager.pause)
        {
            Move();
            if (functionsScript.actionTriggered)
            {
                fear += functionsScript.getScared(transform.Find("Cop1").transform.position, functionsScript.posAction);
            }
        }
    }

    private void Move()
    {

        if (walkingStop == 0)
        {
            obj = new Vector2(2.8f, -14.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 1;

            }
        } 
        else if (walkingStop == 1)
        {
            obj = new Vector2(6.7f, -14.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 2;
                animator.SetBool("Left", true);
                squareR.SetActive(false);
                squareL.SetActive(true);

            }
        }
        else if (walkingStop == 2)
        {
            obj = new Vector2(2.8f, -14.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 3;
            }
        }
        else
        {
            obj = new Vector2(2.8f, -11f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                walkingStop = 0;
                animator.SetBool("Left", false);
                squareR.SetActive(true);
                squareL.SetActive(false);

            }
        }

    }

    private void RunAway()
    {
        if (!running)
        {
            animator.SetBool("Left", true);
            squareR.SetActive(false);
            squareL.SetActive(true);
        }

        running = true;
        speed = 2.5f;


        if (transform.position.x <= 2.8)
        {
            obj = new Vector2(1.6f, -10.5f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, obj) < 0.01f)
            {
                Destroy(this.gameObject);
            }
        } else
        {
            obj = new Vector2(2.8f, -14.75f);
            transform.position = Vector2.MoveTowards(transform.position, obj, speed * Time.deltaTime);
        }

    }
}
