using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFunctions : MonoBehaviour
{    private bool oneThrow = false;
    private string assetBroken;
    private string action;
    private Rigidbody2D objectAction;
    private Vector2 throwImpulse;

    private Component[] items;
    private SpriteRenderer item;
    private bool turnOn = false;

     public void throwObject(Collider2D collider)
    {
        action = "throw";
        if(collider.name != "books")
        {
            collider.SendMessage("makeAction");
        }
        else
        {
            NPCFunctions npcFunctions = GameObject.Find("GameManager").GetComponent<NPCFunctions>();
            npcFunctions.actionTriggered = true;
            npcFunctions.posAction = collider.transform.position;
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.hp -= 10;
        }

        collider.SendMessage("hideMenuHelper");
        assetBroken = collider.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        oneThrow = true;
    }

     public void dropObject(Collider2D collider){
        action = "drop";
        collider.SendMessage("makeAction");
        collider.SendMessage("hideMenuHelper");
        assetBroken = collider.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        oneThrow = true;
     }
     public void turnOnObject(Collider2D collider){
        collider.SendMessage("makeAction");
        collider.SendMessage("hideMenuHelper");
        if(collider.transform.childCount>1){
            items = collider.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in items){
                item.sprite = (Sprite)Resources.Load<Sprite>(item.sprite.name + "On") as Sprite;
            }
        }
        else{
            item = collider.GetComponent<SpriteRenderer>();
            item.sprite = (Sprite)Resources.Load<Sprite>(item.sprite.name + "On") as Sprite;
        }
    }

     public void makeSoundObject(Collider2D collider){
        turnOn = !turnOn;
        collider.SendMessage("hideMenuHelper");
        if(turnOn != false)
            collider.GetComponent<AudioSource>().Play();
        else
            collider.GetComponent<AudioSource>().Stop();
     }

    IEnumerator throwAndChangeSprite(){
        if (action == "throw")
            throwForce();
        else
            dropForce();
        objectAction.AddForce(throwImpulse, ForceMode2D.Impulse);
        oneThrow = false;
        if(action == "throw")
            yield return new WaitForSeconds(2);
        else
            yield return new WaitForSeconds(1);
        if(assetBroken == objectAction.name + "Broken"){
            objectAction.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>(assetBroken) as Sprite;
        }
        if(objectAction.GetComponent<AudioSource>() != null){
            objectAction.GetComponent<AudioSource>().Play();
        }
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
