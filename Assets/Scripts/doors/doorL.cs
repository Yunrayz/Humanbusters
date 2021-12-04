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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.transform.position = new Vector3(0, -12, -10);
            player.transform.position = new Vector3(-5.4f, -11f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(10f * Vector2.down * Time.deltaTime);
        }

    }
}
