using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    public float speed = 1.5f;
    public int fear;        //fear the NPC is feeling
    public int fearLimit;   //limit of Fear before he runs away
    public float radius;    //min distance between the NPC and the action for him to be affected

    //get from interaction scripts
    public bool actionTriggered;
    public float xPosAction;
    public float yPosAction;

    private Rigidbody2D neighborRb;
    private Vector2 direction = Vector2.down;
    private NPCFunctions functionsScript;       //script with functions common to all NPCs

    // Start is called before the first frame update
    void Start()
    {
        neighborRb = GetComponent<Rigidbody2D>();
        fear = 0;
        functionsScript = transform.GetComponent<NPCFunctions>();
    }

    // Update is called once per frame
    void Update()
    {

        if (actionTriggered)
        {
            if (functionsScript.checkDistance(xPosAction, yPosAction, radius))
            {
                fear += 100;
                StartCoroutine(Waiting());
            }
        }

        if (fear > fearLimit)
        {
            functionsScript.runAway(xPosAction, yPosAction);
        } else { 
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

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5);
    }
}
