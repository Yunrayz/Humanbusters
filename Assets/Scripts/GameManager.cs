using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("NPC").Length == 0 && GameObject.FindGameObjectsWithTag("Exorcist").Length == 0 &&
            SceneManager.GetActiveScene().name == "Level 0")
        {
            Debug.Log("You Win");
            SceneManager.LoadScene("Win");
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");

        GameObject.Find("Player").GetComponent<Player>().hp = 200;
        GameObject.Find("Man1").GetComponent<Man1>().fearLimit = 100;
        GameObject.Find("Woman1").GetComponent<Woman1>().fearLimit = 100;
        GameObject.Find("Nun1").GetComponent<Nun1>().fearLimit = 50;
        GameObject.Find("Nun2").GetComponent<Nun2>().fearLimit = 50;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
