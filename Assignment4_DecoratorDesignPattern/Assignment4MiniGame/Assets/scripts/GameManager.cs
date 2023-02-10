using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 3 - Observer Pattern
 * This class manages the game. It's (still) not a singleton but it still gets
 * the job done.
 */
public class GameManager : MonoBehaviour
{
    //general (mostly ui) variables
    public GameObject player;

    public Pizza activePizza;
    public CustomerBehavior activeCustomer;

    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject pauseScreen;

    public bool isGameActive;
    public bool tutorialActive;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;

    // Update is called once per frame
    void Update()
    {
        //pause input
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

    }

    //pause the game
    private void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    //unpause the game
    public void Unpause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    //start the game with selected difficulty
    public void ChangeDifficulty(float numOfSheep)
    {
        //to implement
    }

    //show gameover screen and end the game
    public void GameOver()
    {
        isGameActive = false;
        endScreen.SetActive(true);
        //to implement
    }

    //reset everything and bring player back to start screen
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        startScreen.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }


}
