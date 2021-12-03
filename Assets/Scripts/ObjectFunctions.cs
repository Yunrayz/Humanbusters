using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFunctions : MonoBehaviour
{    private bool oneThrow = false;
    private string assetBroken;
    private string action;
    private Rigidbody2D objectAction;
    private Vector2 throwImpulse;

     public void throwObject(Collider2D collider){
        action = "throw";
        collider.SendMessage("makeAction");
        collider.SendMessage("hideMenuHelper");
        assetBroken = collider.gameObject.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        oneThrow = true;
    }

     public void dropObject(Collider2D collider){
        action = "drop";
        collider.SendMessage("makeAction");
        collider.SendMessage("hideMenuHelper");
        assetBroken = collider.gameObject.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        oneThrow = true;
     }
     public void turnOnOffObject(Collider2D collider){
         
     }

     public void makeSoundObject(Collider2D collider){}

    IEnumerator throwAndChangeSprite(){
        if (action == "throw")
            throwForce();
        else
            dropForce();
        objectAction.AddForce(throwImpulse, ForceMode2D.Impulse);
        oneThrow = false;
        if(action == "throw")
            yield return new WaitForSeconds(2);
        //objectAction.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>(assetBroken) as Sprite;
    }
     void FixedUpdate(){
         if (oneThrow){
            StartCoroutine(throwAndChangeSprite());
         }
     }

     void throwForce(){
           if(objectAction.transform.position.y < 0f && objectAction.transform.position.x < -3f){
            throwImpulse = new Vector2(5f, 0f);
        }
            else{
                throwImpulse = new Vector2(0f, -5f);
        }
     }
     void dropForce(){
          if(objectAction.transform.position.y < 0f && objectAction.transform.position.x < -3f){
            throwImpulse = new Vector2(2f, 0f);
        }
            else{
                throwImpulse = new Vector2(0f, -2f);
        }
     }
}
