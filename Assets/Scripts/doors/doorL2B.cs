using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorL2B : MonoBehaviour
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
        if (Vector2.Distance(player.transform.position, new Vector2(5.5f, 1.2f)) < 0.5)
        {
            mainCamera.transform.position = new Vector3(23.19f, -12.7f, -10);
            player.transform.position = new Vector3(26.5f, -16.5f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(10f * Vector2.down);
        }
    }
}