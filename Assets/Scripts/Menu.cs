using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : ObjectFunctions
{
    // Dynamic Menu Test Class
    public List<GameObject> buttonList = new List<GameObject>();
    void Start()
    {
        
    }
    public void addButtons(Dictionary<string, System.Action> dict){

        foreach (var i in dict){
            GameObject tempObject = new GameObject();
            tempObject.name = i.Key;
            tempObject.AddComponent<Button>();
            Button tempButton = tempObject.GetComponent<Button>();
            tempButton.onClick.AddListener(test);
           buttonList.Add(tempObject);
        }
    }
    void test (){
        Debug.Log("testttt");
    }  
    // Update is called once per frame
    void Update()
    {
        
    }
}
