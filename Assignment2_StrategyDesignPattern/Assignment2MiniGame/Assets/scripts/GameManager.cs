using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public float spawnRate = 3.0f;
    public List<GameObject> fruits;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        scoreText.text = "Score: " + score;
        if (score >= 30)
        {
            GameOver();
        }

        //tutorial stuff
        if (tutorialActive)
        {
            if (tutorialStep == 0)
            {
                tutorialText.text = "Welcome to Fruit Fall!\nUse <- and -> (recomended) or A and D to move.";
                if (Mathf.Abs(player.transform.position.x) > 5)
                {
                    tutorialStep = 1;
                }
            }
            else if (tutorialStep == 1)
            {
                tutorialText.text = "To change the color of your bowl, press Q (red), W (orange) or E (yellow).";
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))
                {
                    tutorialStep = 2;
                }
            }
            else if (tutorialStep == 2)
            {
                tutorialText.text = "To catch a falling fruit, the color of your basket must match the color of the fruit!";
                isGameActive = true;
                exampleImages.SetActive(true);
                if (!calledOnce)
                {
                    StartCoroutine(SpawnFruits());
                    calledOnce = true;
                }
                if (score >= 1)
                {
                    tutorialStep = 3;
                }
            }
            else if (tutorialStep == 3)
            {
                tutorialText.text = "Great job!\nTo complete the tutorial, try catching "+ (5-score)+ " more!";
                if (score >= 5)
                {
                    tutorialStep = 4;
                    GameOver();
                }
            }
        }
    }

    private void Pause()
    {
        //isGameActive = false;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        //isGameActive = true;
        pauseScreen.SetActive(false);
    }

    public void ChangeDifficulty(float spawnRate)
    {
        this.spawnRate = spawnRate;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnFruits());
        startScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (tutorialActive)
        {
            winScoreText.text = "When you play for real, you'll need 30 points to win!";
        }
        else 
        {
            winScoreText.text = "Score to Win: 30";
        }
        endScreen.gameObject.SetActive(true);
        if (score >= 30)
        {
            endText.text = "You Win! :)";
        }
        else if (tutorialActive)
        {
            endText.text = "Tutorial Compelted!";
        }
        else 
        {
            endText.text = "Game Over :(";
        }
        endScoreText.text = "Final Score: " + score;
        isGameActive = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        score = 0;
        tutorialActive = false;
        exampleImages.SetActive(false);
        tutorialText.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }

    public void Tutorial()
    {
        startScreen.gameObject.SetActive(false);
        tutorialText.gameObject.SetActive(true);
        tutorialActive = true;

        
    }


    IEnumerator SpawnFruits()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, fruits.Count);
            Instantiate(fruits[index]);
        }
    }
}
