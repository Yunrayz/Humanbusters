using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collidable : MonoBehaviour
{
    // Start is called before the first frame update
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    private bool triggerActive = false;
    //public Text helperText;

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

      public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = true;
      //          helperText.gameObject.SetActive(true);
            }
        }
 
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = false;
        //        helperText.gameObject.SetActive(false);
            }
        }
    protected virtual void Update(){
        boxCollider.OverlapCollider(filter, hits );
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
                continue;
            triggerActive = true;
            if (triggerActive && Input.GetKeyDown(KeyCode.F))
            {
                onCollide(boxCollider);
            }
            hits[i] = null;
        }
         
        
    }
      
 
        public void SomeCoolAction()
        {
            Debug.Log("test");
        }
    protected virtual void onCollide(Collider2D coll){
        
    }
}
