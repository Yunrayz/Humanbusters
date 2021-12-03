using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collidable
{
    public Canvas itemCanvas;
    
   
    // public Menu menu;
    // public Collidable collidable;
    protected override void Start()
    {
        base.Start();
        // Dictionary<string, System.Action> test = new Dictionary<string, System.Action>();
        // test.Add("Throw", delegate {menu.throwObject(collidable.boxCollider);});
        // test.Add("Drop", delegate {menu.dropObject(collidable.boxCollider);});
        // menu.addButtons(test);
        // Debug.Log(menu.buttonList);
        itemCanvas.gameObject.SetActive(false);
        helperCanvas.gameObject.SetActive(false);

        

    }
    protected override void OnTriggerExit2D(Collider2D other){
        base.OnTriggerExit2D(other);
        hideMenu(itemCanvas);
    }
   protected override void Update(){
       base.Update();
       if (itemCanvas.gameObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape)){
           hideMenu(itemCanvas);
       }
       
   }

   protected void hideMenuHelper(){
       hideMenu(itemCanvas);
   }
    protected override void onCollide(Collider2D other)
    {
        showMenu(itemCanvas);
    }

}
