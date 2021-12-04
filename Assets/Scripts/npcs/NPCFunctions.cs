using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFunctions : MonoBehaviour
{

    public bool actionTriggered;
    public Vector2 posAction;
    public bool effectDone;
    int fear;

    private void Start()
    {
        effectDone = false;
    }

    public int getScared (Vector2 posNPC, Vector2 posAction, float radius)
    {
        fear = 0;
        if (Vector2.Distance(posNPC, posAction) < 2)
        {
            fear = 25;
            actionTriggered = false;
        }

        return fear;
    }

    
    public void stopMovement(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        actionTriggered = false;
    }
}
