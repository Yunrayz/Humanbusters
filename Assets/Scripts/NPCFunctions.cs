using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkDistance (float xPosAction, float yPosAction, float radius)
    {
        float xDistance = Mathf.Abs(transform.position.x - xPosAction);
        float yDistance = Mathf.Abs(transform.position.y - yPosAction);

        return xDistance < radius && yDistance < radius;
    }

    public void runAway (float xPosAction, float yPosAction)
    {
        //animation & disappear, destroy NPC
    }
}
