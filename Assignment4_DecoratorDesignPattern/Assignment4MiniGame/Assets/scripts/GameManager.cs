using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 4 - Decorator Pattern
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

    public float score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;

    //add something so that if the active pizza is cooked, the topping buttons disapear so you can't add any more and have to either trash it or get negative points.
    public GameObject[] addToppingButtons;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + score;

    }

    //reset everything and bring player back to start screen
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


}
