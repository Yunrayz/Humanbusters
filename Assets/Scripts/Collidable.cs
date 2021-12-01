using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    public BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public bool actionMade = false;
    private Movement simon;
    private bool menuActive = false;
    public Canvas helperCanvas;
    public TMP_Text helperText;
    private Vector3 menuPosition; 

    protected virtual void Start(){
        Vector3 objectPosition = gameObject.transform.position;
        menuPosition = new Vector3(objectPosition.x, objectPosition.y+1.7f, objectPosition.z);
        boxCollider = GetComponent<BoxCollider2D>();
        simon = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

 
    protected virtual void Update(){
        boxCollider.OverlapCollider(filter, hits );
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
                continue;
            if(!actionMade)    
                helperTextGenerator();
            if (Input.GetKeyDown(KeyCode.F))
                onCollide(boxCollider);
            hits[i] = null;
        }
         
        
    }

    protected void helperTextGenerator(){
        if(!menuActive){
            helperText.text = "Press F to interact";
        }
        else{
             helperText.text = "Press ENTER to fire an action, ESC to close";
            
        }
        helperCanvas.gameObject.SetActive(true);
    }
    protected virtual void onCollide(Collider2D coll){  
    }

    protected virtual void OnTriggerExit2D(Collider2D other){
        helperCanvas.gameObject.SetActive(false);
     }
    protected void hideMenu(Canvas canvas){
        canvas.gameObject.SetActive(false);
        menuActive = false;
        simon.canMove = true;
    }

    protected void makeAction(){
        actionMade = true;
    }
    protected virtual void showMenu(Canvas canvas){
        if(!actionMade){
        canvas.gameObject.transform.SetPositionAndRotation(menuPosition, Quaternion.identity);
        canvas.gameObject.SetActive(true);
        menuActive = true;
        simon.canMove = false;
        }
    }
}
