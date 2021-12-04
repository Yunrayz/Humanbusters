using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        if (isGameOver)
        {
            GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    void GameOver()
    {
        GameObject.Find("Main Menu").SetActive(false);
        GameObject.Find("Game Over").SetActive(true);
        GameObject.Find("UI to return").SetActive(true);
    }

    void GoToMainMenu()
    {
        GameObject.Find("Game Over").SetActive(false);
        GameObject.Find("UI to return").SetActive(false);
        GameObject.Find("Main Menu").SetActive(true);
    }
}
