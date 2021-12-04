using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");

        GameObject.Find("MainMenu").SetActive(false);
        GameObject.Find("Game Over").SetActive(true);

        //mainMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    public void GoToMainMenu()
    {
        gameOver.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
