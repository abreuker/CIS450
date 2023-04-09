using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 10 - Singleton and Object Pooling Patterns
 * Singleton Game Manager that manages the menus, score, and spawning coroutines. 
 */
public class GameManager : Singleton<GameManager>
{
    public static GameManager instance;
    public float sideScrollerSpeed = 20;
    public bool gamePaused;
    public string[] obstacleTags = new string[] { "Short", "Medium", "Tall" };
    public float distanceTraveled;
    public float playerSpeed;

    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject tutorialScreen;

    public TextMeshProUGUI endText;

    public TextMeshProUGUI tutorialText;
    public string[] tutorialStrings;
    public string currentTutorialString;
    public int tutorialIndex;

    public Image frogImage;

    public Vector2[] spawnPos;

    public bool firstTimePlayed;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            //make sure this object pooler persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton GameManager");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = true;
        firstTimePlayed = true;
        //StartCoroutine(SpawnScrollingObjects());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            distanceTraveled += Time.deltaTime * playerSpeed;
            if (distanceTraveled >= 630)
            {
                Win();
            }
        }
    }

    public void Win()
    { 
        endScreen.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
        endText.text = "You Win!\nTry Again?";
        StopCoroutine(SpawnScrollingObjects());

    }

    public void Lose()
    {
        endScreen.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
        endText.text = "You Lose :(\nTry Again?";
        StopCoroutine(SpawnScrollingObjects());
    }

    public IEnumerator SpawnScrollingObjects()
    {
        while (!gamePaused)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            int randIndex = Random.Range(0, 3);
            Debug.Log(randIndex);
            ObjectPooler.instance.SpawnFromPool(obstacleTags[randIndex], spawnPos[randIndex], Quaternion.identity);
        }
    }

    public void BackToMenu()
    {
        endScreen.SetActive(false);
        startScreen.SetActive(true);
    }
    public void StartTutorial()
    {
        startScreen.SetActive(false);
        tutorialScreen.SetActive(true);
        currentTutorialString = tutorialStrings[0];
        tutorialText.text = currentTutorialString;
        tutorialIndex = 1;
    }
    public void TutorialNextButton()
    {
        if (currentTutorialString != tutorialStrings[tutorialStrings.Length-1])
        {
            currentTutorialString = tutorialStrings[tutorialIndex];
            tutorialText.text = currentTutorialString;
            tutorialIndex++;
        }
    }
    public void Play()
    {
        
        distanceTraveled = 0;
        frogImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-319, 10, 0);

        startScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        endScreen.SetActive(false);

        gamePaused = false;

        Time.timeScale= 1.0f;

        if (firstTimePlayed)
        {
            StartCoroutine(SpawnScrollingObjects());
            firstTimePlayed= false;
        }
        
    }
}
