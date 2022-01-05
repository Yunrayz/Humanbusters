using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject Simon;
    public bool startingLevel;
    private Vector2 obj;
    private string nameLevel;

    private void Start()
    {
        Simon = GameObject.Find("Ghost");
        startingLevel = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("NPC").Length == 0 && GameObject.FindGameObjectsWithTag("Exorcist").Length == 0 &&
            SceneManager.GetActiveScene().name == "Level 0")
        {
            SceneManager.LoadScene("Win");
        }
        if (startingLevel)
        {
            Simon.transform.position = Vector2.MoveTowards(Simon.transform.position, obj, 1.5f * Time.deltaTime);
            if (Vector2.Distance(Simon.transform.position, new Vector2(-4.7f, 0)) < 0.01f)
            {
                startingLevel = false;
                SceneManager.LoadScene(nameLevel);
            }
        }
    }

    public void StartLevel1()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        obj = new Vector2(-4.7f, 0);
        nameLevel = "Level 0";
        startingLevel = true;
    }

    public void StartLevel2()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        new Vector2(-4.7f, 0);
        nameLevel = "Level 0";
        startingLevel = true;
    }

    public void StartLevel3()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        new Vector2(-4.7f, 0);
        nameLevel = "Level 0";
        startingLevel = true;
    }

    public void StartGame()
    {

        SceneManager.LoadScene("Level 0");
        /*
        GameObject.Find("Player").GetComponent<Player>().hp = 200;
        GameObject.Find("Man1").GetComponent<Man1>().fearLimit = 100;
        GameObject.Find("Woman1").GetComponent<Woman1>().fearLimit = 100;
        GameObject.Find("Nun1").GetComponent<Nun1>().fearLimit = 50;
        GameObject.Find("Nun2").GetComponent<Nun2>().fearLimit = 50;*/
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
