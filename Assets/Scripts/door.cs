using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            loadScene();

    }

    private void loadScene()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "living room")
            {
                SceneManager.LoadScene("Kitchen");
            }
            else
            {
                SceneManager.LoadScene("living room");
            }
        }
    }
}
