using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private bool timeIsPassed;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        timeIsPassed = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeRoom();
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space)) 
        {
            changeRoom();
        }

    }*/


    private void changeRoom()
    {
        if (Vector2.Distance(transform.position, new Vector2(-5.5f, -10)) < 1)
        {
            mainCamera.transform.position = new Vector3(0, -12, -10);
            player.transform.position = new Vector3(-5.4f, -11f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(10f * Vector2.down * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, new Vector2(5.6f, -4.5f)) < 1)
        {
            mainCamera.transform.position = new Vector3(0, -0, -10);
            player.transform.position = new Vector3(5.6f, -4.5f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(10f * Vector2.up * Time.deltaTime);
        }
    }
}