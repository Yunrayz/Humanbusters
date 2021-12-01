using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : Collidable
{
    public Canvas booksCanvas;
   
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
        booksCanvas.gameObject.SetActive(false);
        helperCanvas.gameObject.SetActive(false);

        

    }
    protected override void OnTriggerExit2D(Collider2D other){
        base.OnTriggerExit2D(other);
        hideMenu(booksCanvas);
    }
   protected override void Update(){
       base.Update();
       if (booksCanvas.gameObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape)){
           hideMenu(booksCanvas);
       }
       
   }

   protected void hideMenuHelper(){
       hideMenu(booksCanvas);
   }
    protected override void onCollide(Collider2D other)
    {
        showMenu(booksCanvas);
    }

}
