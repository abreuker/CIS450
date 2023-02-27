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
    //general variables
    public SpaceFolkSpawner spawner;
    public float spawnRate = 3.0f;
    public GameObject player;

    public GameObject startScreen;
    public GameObject endScreen;

    public float speedMod;
    public float distanceLeft = 300;
    public TextMeshProUGUI distanceLeftText;

    public bool isGameActive;

    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI winScoreText;

    public bool textRead;
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;
    public GameObject enemyExampleImage;
    public GameObject powerupGoodExampleImage;
    public GameObject powerupBadExampleImage;

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        { 
            distanceLeft -= Time.deltaTime * speedMod;
            distanceLeftText.text = "distance left: " + distanceLeft + "m";
            scoreText.text = "score: " + score;
        }
        //scoreText.text = "score : " + score;
        if (distanceLeft <= 0)
        {
            GameOver();
        }
    }


    //start the game with selected difficulty
    public void ChangeDifficulty(float spawnRate)
    {
        Time.timeScale = 1;
        this.spawnRate = spawnRate;
        isGameActive = true;
        spawner.StartRandomSpawns();
        startScreen.gameObject.SetActive(false);
    }

    //show gameover screen and end the game
    public void GameOver()
    {
        isGameActive = false;
        endScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        if (distanceLeft <= 0)
        {
            endText.text = "You Win! :)";
            endScoreText.text = "Final Score: " + score + "\nDistance Remaining: " + distanceLeft;

        }
        else
        {
            endText.text = "You lose :(";
            endScoreText.text = "Final Score: " + score + "\nDistance Remaining: " + distanceLeft;
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

    public void ContinueButton()
    {
        textRead = true;  
    }

    public void TutorialStart()
    { 
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial() 
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = "To move, use W and S or up and down arrows.\n\nTo shoot, press SPACE.";
        yield return new WaitUntil(() => textRead);

        textRead= false;
        enemyExampleImage.SetActive(true);
        tutorialText.text = "These are enemies.\n\nShoot them to get more points, avoid them to stay alive.";
        yield return new WaitUntil(() => textRead);

        textRead = false;
        enemyExampleImage.SetActive(false);
        powerupGoodExampleImage.SetActive(true);
        tutorialText.text = "Sometimes, powerups will appear on screen!\n\nThese are good ones, if you collect them, an ally will appear to help you!";
        yield return new WaitUntil(() => textRead);

        textRead = false;  
        powerupGoodExampleImage.SetActive(false);
        powerupBadExampleImage.SetActive(true);
        tutorialText.text = "There's also bad powerups.\n\nThese call more enemies.";
        yield return new WaitUntil(() => textRead);

        textRead = false;
        powerupBadExampleImage.SetActive(false);
        tutorialText.text = "Each powerup calls different allies or enemies based on their color.\n\nBe sure to pay attention!";
        yield return new WaitUntil(() => textRead);

        textRead = false;
        tutorialText.text = "To win, you need to reach your destination.\n\nA meter will be counting down in the top lefthand corner.";
        yield return new WaitUntil(() => textRead);

        textRead = false;
        tutorialText.text = "That's it! Press the 'Back To Menu' button to head back to the menu and try it out!";
    }

}

