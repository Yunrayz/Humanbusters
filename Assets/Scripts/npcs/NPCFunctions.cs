using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCFunctions : MonoBehaviour
{

    public bool actionTriggered;
    public Vector2 posAction;
    int fear;
    private Player player;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 0")
            player = GameObject.Find("Player").GetComponent<Player>();
    }


    public int getScared (Vector2 posNPC, Vector2 posAction, float radius)
    {
        fear = 0;
        float distance = Vector2.Distance(posNPC, posAction);
        if (distance < 2)
        {
            fear = 15;
            actionTriggered = false;
            if (distance < 0.8f)
            {
                player.hp += 20;
                fear *= 2;
            }
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
