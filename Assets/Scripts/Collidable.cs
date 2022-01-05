using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collidable : MonoBehaviour
{
    protected ContactFilter2D filter;
    protected BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    protected bool actionMade = false;
    private Player simon;
    private bool menuActive = false;
    public Canvas helperCanvas;
    public TMP_Text helperText;
    private Vector2 menuPosition;

    protected Transform thisTransform;
    protected Vector2 startPosition;
    protected Vector2 objectPosition;
    public int menuOptions;

    private NPCFunctions npcFunctions;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        simon = GameObject.FindWithTag("Player").GetComponent<Player>();
        thisTransform = transform;

        npcFunctions = GameObject.Find("Game Manager").GetComponent<NPCFunctions>();
    }


    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null || hits[i].tag == "Ignore" || hits[i].tag == "Exorcist" || hits[i].tag == "NPC")
                continue;
            if (!actionMade)
                helperTextGenerator();
            if (Input.GetKeyDown(KeyCode.F))
                onCollide(boxCollider);
            hits[i] = null;
        }



    }
    protected void FixedUpdate()
    {
        objectPosition = thisTransform.position;
        setMenuPosition(menuOptions, objectPosition);
    }
    protected void helperTextGenerator()
    {
        if (!menuActive)
        {
            helperText.text = "Press F to interact with " + boxCollider.name;
        }
        else
        {
            helperText.text = "Press ENTER to fire an action, ESC to close";

        }
        helperCanvas.gameObject.SetActive(true);
    }
    protected virtual void onCollide(Collider2D coll)
    {
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        helperCanvas.gameObject.SetActive(false);
    }
    protected void hideMenu(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
        menuActive = false;
        simon.canMove = true;
        helperCanvas.gameObject.SetActive(false);
    }

    protected void makeAction()
    {
        actionMade = true;
        npcFunctions.actionTriggered = true;
        npcFunctions.posAction = this.transform.position;
        simon.GetComponent<Player>().hp -= 10;
    }


    protected virtual void showMenu(Canvas canvas)
    {
        if (!actionMade)
        {
            simon.canMove = false;
            canvas.gameObject.transform.SetPositionAndRotation(menuPosition, Quaternion.identity);
            canvas.gameObject.SetActive(true);
            menuActive = true;
        }
    }

    protected void setMenuPosition(int menuOptions, Vector2 objectPosition)
    {
        if (menuOptions == 2)
            menuPosition = new Vector2(objectPosition.x, objectPosition.y + 1.7f);
        else if (menuOptions == 3)
        { }
        else
            menuPosition = new Vector2(objectPosition.x, objectPosition.y + 1.15f);
    }
}
