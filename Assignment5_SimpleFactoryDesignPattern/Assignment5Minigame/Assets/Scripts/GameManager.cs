using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 5 - Simple Factory Pattern
 * This class manages the game.
 */
public class GameManager : MonoBehaviour
{
    //general (mostly ui) variables
    public float spawnRate = 3.0f;
    public GameObject player;

    public SpawnManager spawnManager;

    public GameObject startScreen;
    public GameObject endScreen;


    public bool isGameActive;


    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score : " + score;
        if (score >= 250)
        {
            GameOver();
        }
    }


    //start the game with selected difficulty
    public void ChangeDifficulty(float spawnRate)
    {
        this.spawnRate = spawnRate;
        isGameActive = true;
        startScreen.gameObject.SetActive(false);
        spawnManager.StartSpawning();
    }

    //show gameover screen and end the game
    public void GameOver()
    {
        isGameActive= false;
        endScreen.gameObject.SetActive(true);
        Time.timeScale= 0;
        if (score >= 250)
        {
            endText.text = "You Win! :)";
            endScoreText.text = "Final Score: " + score;

        }
        else 
        {
            endText.text = "You lose :(";
            endScoreText.text = "Final Score: " + score + "\nYou need 250 to win.";
        }
        
    }

    //reset everything and bring player back to start screen
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        startScreen.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }


}
