using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorL : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private bool timeIsPassed;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeRoom();
            
        }
    }

    private void changeRoom()
    {
        if (Vector2.Distance(player.transform.position, new Vector2(5.6f, -4.5f)) < 0.5)
        {
            mainCamera.transform.position = new Vector3(0, -12, -10);
            player.transform.position = new Vector3(-5.4f, -11f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(10f * Vector2.down);
        }
    }
}
