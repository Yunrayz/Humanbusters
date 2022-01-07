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
            (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" ||
            SceneManager.GetActiveScene().name == "Level 3"))
        {
            SceneManager.LoadScene("Win");
        }
        if (startingLevel)
        {
            Simon.transform.position = Vector2.MoveTowards(Simon.transform.position, obj, 1.5f * Time.deltaTime);
            if (Vector2.Distance(Simon.transform.position, obj) < 0.01f)
            {
                startingLevel = false;
                SceneManager.LoadScene(nameLevel);
            }
        }
    }

    public void StartLevel1()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        obj = new Vector2(-5.4f, 0);
        nameLevel = "Level 1";
        startingLevel = true;
    }

    public void StartLevel2()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        obj = new Vector2(-3.1f, -1.2f);
        nameLevel = "Level 1";
        startingLevel = true;
    }

    public void StartLevel3()
    {
        GameObject.Find("Story 6").gameObject.SetActive(false);
        obj = new Vector2(-1.5f, -2);
        nameLevel = "Level 1";
        startingLevel = true;
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
