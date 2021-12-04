using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFunctions : MonoBehaviour
{

    public bool actionTriggered;
    public Vector2 posAction;

    
    public bool checkDistance (Vector2 posNPC, Vector2 posAction, float radius)
    {
        return Vector2.Distance(posNPC, posAction) < 2;
    }

    
    public void stopMovement(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
    }
}
