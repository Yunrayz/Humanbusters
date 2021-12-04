using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collidable
{
    public Canvas itemCanvas;
    public bool switchable;
    protected override void Start()
    {
        base.Start();
        itemCanvas.gameObject.SetActive(false);
        helperCanvas.gameObject.SetActive(false);

        

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
