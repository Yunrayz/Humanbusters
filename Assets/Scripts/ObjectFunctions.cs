using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFunctions : MonoBehaviour
{
    private bool oneThrow = false;
    private string assetBroken;
    private string action;
    private Rigidbody2D objectAction;
    private Vector2 throwImpulse;

    private Component[] items;
    private SpriteRenderer spriteComponent;
    private bool turnOn = false;

    private Item itemObject;
    private AudioSource audioComponent;

    private bool firstThrow = true;

    public void throwObject(Collider2D collider)
    {
        action = "throw";
        if (collider.name != "books" && collider.name != "chair")
        {
            collider.SendMessage("makeAction");
        }
        else
        {
            NPCFunctions npcFunctions = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
            npcFunctions.actionTriggered = true;
            npcFunctions.posAction = collider.transform.position;
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.hp -= 10;
        }

        collider.SendMessage("hideMenuHelper");
        if (firstThrow)
        {
            collider.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
            firstThrow = false;
        }
        assetBroken = collider.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        oneThrow = true;
        itemObject = collider.GetComponent<Item>();
        audioComponent = objectAction.GetComponent<AudioSource>();
    }

    public void dropObject(Collider2D collider)
    {
        action = "drop";
        collider.SendMessage("makeAction");
        collider.SendMessage("hideMenuHelper");
        assetBroken = collider.GetComponent<SpriteRenderer>().sprite.name + "Broken";
        objectAction = collider.attachedRigidbody;
        itemObject = collider.GetComponent<Item>();
        audioComponent = objectAction.GetComponent<AudioSource>();
        oneThrow = true;
    }
    public void turnOnObject(Collider2D collider)
    {
        turnOn = !turnOn;
        audioComponent = collider.GetComponent<AudioSource>();
        collider.SendMessage("hideMenuHelper");

        NPCFunctions npcFunctions = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        npcFunctions.actionTriggered = true;
        npcFunctions.posAction = collider.transform.position;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.hp -= 10;

        if (turnOn == true)
        {
            if (collider.transform.childCount > 1)
            {
                items = collider.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer spriteComponent in items)
                {
                    spriteComponent.sprite = (Sprite)Resources.Load<Sprite>(spriteComponent.sprite.name + "On") as Sprite;
                }
            }
            else
            {
                spriteComponent = collider.GetComponent<SpriteRenderer>();
                spriteComponent.sprite = (Sprite)Resources.Load<Sprite>(spriteComponent.sprite.name + "On") as Sprite;
            }

            audioComponent.Play();
        }
        else
        {
            if (collider.transform.childCount > 1)
            {
                items = collider.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer spriteComponent in items)
                {
                    spriteComponent.sprite = (Sprite)Resources.Load<Sprite>(spriteComponent.name) as Sprite;
                }
            }
            else
            {
                spriteComponent = collider.GetComponent<SpriteRenderer>();
                spriteComponent.sprite = (Sprite)Resources.Load<Sprite>(spriteComponent.name) as Sprite;
            }
            audioComponent.Stop();
        }
    }

    public void makeSoundObject(Collider2D collider)
    {

        NPCFunctions npcFunctions = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
        npcFunctions.actionTriggered = true;
        npcFunctions.posAction = collider.transform.position;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.hp -= 10;

        turnOn = !turnOn;
        audioComponent = collider.GetComponent<AudioSource>();
        collider.SendMessage("hideMenuHelper");
        if (turnOn != false)
            audioComponent.Play();
        else
            audioComponent.Stop();
    }

    IEnumerator throwAndChangeSprite()
    {
        if (action == "throw")
            throwForce();
        else
            dropForce();
        objectAction.AddForce(throwImpulse, ForceMode2D.Impulse);
        oneThrow = false;
        if (action == "throw")
            yield return new WaitForSeconds(2);
        else
            yield return new WaitForSeconds(1);
        if (assetBroken == objectAction.name + "Broken" && itemObject.isBreakable)
        {
            objectAction.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>(itemObject.transform.parent.name + "/" + assetBroken) as Sprite;
        }

        if (audioComponent != null && !itemObject.isSwitchable)
        {
            audioComponent.Play();
        }
        if (audioComponent != null & itemObject.isSwitchable)
        {
            audioComponent.PlayOneShot(Resources.Load(audioComponent.name + "Sound") as AudioClip);
        }
    }
    void FixedUpdate()
    {
        if (oneThrow)
        {
            StartCoroutine(throwAndChangeSprite());
        }
    }

    void throwForce()
    {
        throwImpulseX();
        throwImpulseY();
    }
    void dropForce()
    {
        if (objectAction.transform.position.y < 0f && objectAction.transform.position.x < -3f)
        {
            throwImpulse = new Vector2(2f, 0f);
        }
        else
        {
            throwImpulse = new Vector2(0f, -2f);
        }
    }
    void throwImpulseX()
    {
        if (objectAction.transform.position.x > 2f)
            throwImpulse.x = Random.Range(-5f, 2f);
        else
            throwImpulse.x = Random.Range(-1f, 5f);
    }
    void throwImpulseY()
    {
        if (objectAction.transform.position.y < 0f)
            throwImpulse.y = Random.Range(0f, 4f);
        else
            throwImpulse.y = Random.Range(-4f, 0f);
    }
}
