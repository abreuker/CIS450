using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;

    private int tutorialStep;
    public TextMeshProUGUI tutorialText;
    public GameObject exampleImages;
    private bool calledOnce = false;

    public GameObject sheep;
    public List<GameObject> sheepPlural = new List<GameObject>();
    public GameObject coyote;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            timerText.text = "Time Remaining: " + (60 - Mathf.FloorToInt(timer));
        }
        //pause input
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        //check if game is won CHANGE LOSS CONDITION
        if (timer >= 60)
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
    public void ChangeDifficulty(float numOfSheep)
    {
        this.spawnRate = ((1/numOfSheep)*10);
        isGameActive = true;
        timer = 0;
        startScreen.gameObject.SetActive(false);
        for(int i = 0; i < numOfSheep; i++) 
        {
            Instantiate(sheep);
        }
        StartCoroutine(SpawnCoyote());
    }

    //show gameover screen and end the game
    public void GameOver()
    {
        isGameActive = false;
        endScreen.SetActive(true);
        if (timer >= 60)
        {
            endText.text = "All the sheep will be sleeping safe and sound tonight! :) \nYou win!";
        }
        else 
        {
            endText.text = "Oh no, looks like you lost a sheep! :( \nTry Again?";
        }
        endScoreText.text = "Time Remaining: " + (60- Mathf.FloorToInt(timer));
    }

    //reset everything and bring player back to start screen
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        timer = 0;
        tutorialActive = false;
        startScreen.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }

    //start the tutorial
    public void Tutorial()
    {

    }

    IEnumerator SpawnCoyote() 
    {
        while (isGameActive) 
        { 
            yield return new WaitForSeconds(spawnRate);
            Instantiate(coyote);
        }
    }

}
