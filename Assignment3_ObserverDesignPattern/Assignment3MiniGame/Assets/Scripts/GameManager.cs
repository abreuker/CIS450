using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 2 - Strategy Pattern
 * This class manages the game. It's not a singleton but it still gets
 * the job done.
 */
public class GameManager : MonoBehaviour
{
    public int score;
    public float spawnRate = 3.0f;
    public float numOfSheep;
    public GameObject player;

    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject pauseScreen;

    public bool isGameActive;
    public bool tutorialActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;

    private int tutorialStep;
    public TextMeshProUGUI tutorialText;
    public GameObject exampleImages;
    private bool calledOnce = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //pause input
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        //update score text
        scoreText.text = "Score: " + score;

        //check if game is won CHANGE LOSS CONDITION
        if (score >= 30)
        {
            GameOver();
        }

        //tutorial stuff
        if (tutorialActive)
        {
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
    public void ChangeDifficulty(float numOfSheep, float spawnRate)
    {

    }

    //show gameover screen and end the game
    public void GameOver()
    {
        isGameActive = false;
    }

    //reset everything and bring player back to start screen
    public void Restart()
    {

    }

    //start the tutorial
    public void Tutorial()
    {

    }


}
