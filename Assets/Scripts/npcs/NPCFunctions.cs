using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFunctions : MonoBehaviour
{

    public bool actionTriggered;
    public Vector2 posAction;
    bool effectDone;


    public int getScared (Vector2 posNPC, Vector2 posAction, float radius)
    {
        int fear;

        if (Vector2.Distance(posNPC, posAction) < 2)
        {
            fear = 25;
            effectDone = true;
        } else
        {
            fear = 0;
        }
        
        if (effectDone){
            actionTriggered = false;
            effectDone = false;
        } else
        {
            StartCoroutine(Waiting());
        }

        return fear;
    }

    
    public void stopMovement(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        actionTriggered = false;
    }
}
