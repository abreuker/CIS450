using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 * Anna Breuker
 * Timedpets.cs
 * Assignment 8 - Template Pattern
 * A powerup that is a subclass of the powerup button superclass.
 * Makes all clicks do 10x pets for 30 seconds.
 */
public class Timedpets : PowerupButtonSuperclass
{
    public GameObject tutorialText;
    public GameObject timer;
    public float boostTime;
    public bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.FindGameObjectWithTag("TimedpetText");
        tutorialText.SetActive(false);

        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        powerupName = "TIMEDPETS";
        cost = 100;

        boostTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = powerupName + " Cost: " + cost;
        if(startTimer) 
        {
            boostTime += Time.deltaTime;
            timer.SetActive(true);
            timer.GetComponent<TextMeshProUGUI>().text = "TIMEDPETS TIMER: " + Mathf.Round(30 - boostTime);
            if (boostTime >= 30) 
            {
                timer.SetActive(false);
                startTimer = false;
            }
        }

    }

    public override void MakeNumberGoUp()
    {
        StartCoroutine(TimedBoost());
        gameManager.kittiesKlicked -= cost;
        cost *= 30;
    }

    public override IEnumerator ShowTutorialText()
    {
        tutorialText.SetActive(true);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        tutorialText.SetActive(false);
    }

    protected override bool IsFirstButtonPressed()
    {
        if (cost == 100)
        {
            firstTimePressed = true;
        }
        else
        {
            firstTimePressed = false;
        }
        return firstTimePressed;
    }

    public IEnumerator TimedBoost()
    {
        boostTime = 0;
        startTimer = true;
        gameManager.clickValue *= 10;
        yield return new WaitForSeconds(30);
        gameManager.clickValue /= 10;
        //yield return new WaitUntil(() => );
    }
}
