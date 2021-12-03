using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man1 : MonoBehaviour
{
    public float speed = 1.5f;
    public int fear;                //fear the NPC is feeling
    public int fearLimit = 100;     //limit of Fear before he runs away
    public float radius = 2;        //min distance between the NPC and the action for him to be affected
    private bool running;


    //get from interaction scripts

    private Rigidbody2D neighborRb;
    private Vector2 direction = Vector2.down;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs
    private AudioSource audioSource;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        neighborRb = GetComponent<Rigidbody2D>();
        fear = 0;
        functionsScript = GameObject.Find("GameManager").GetComponent<NPCFunctions>();
        audioSource = GetComponent<AudioSource>();
        running = false;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (fear >= fearLimit)
        {
            if (!running)
                audioSource.Play();
            RunAway();
        } else if (functionsScript.actionTriggered)
        {
            if (functionsScript.checkDistance(transform.position, functionsScript.posAction, radius))
            {
                fear += 10;
            }
            functionsScript.actionTriggered = false;
        } else if (player.hp <= 0)
        {
            functionsScript.stopMovement(neighborRb);
        }
        else { 
            Move(); 
        }

    }

    private void Move()
    {

        if (transform.position.y >= 0)
        {
            direction = Vector2.down;
            neighborRb.velocity = speed * direction;
        }
        else if (transform.position.y <= -2.5)
        {
            direction = Vector2.up;
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
        if (transform.position.y < 1)
            neighborRb.velocity = speed * Vector2.up;
        else if (transform.position.x < 5.5)
            neighborRb.velocity = speed * Vector2.right;
        else if (transform.position.y < 1.8)
            neighborRb.velocity = speed * Vector2.up;
        else
            Destroy(this.gameObject);
    }
}
