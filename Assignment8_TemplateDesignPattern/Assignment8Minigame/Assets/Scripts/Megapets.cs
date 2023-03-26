using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 * Anna Breuker
 * Megapets.cs
 * Assignment 8 - Template Pattern
 * A powerup that is a subclass of the powerup button superclass.
 * Permanently doubles the amount of pets a single click gets you.
 */
public class Megapets : PowerupButtonSuperclass
{
    public GameObject tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        firstTimePressed = true;

        tutorialText = GameObject.FindGameObjectWithTag("MegapetText");
        tutorialText.SetActive(false);

        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        powerupName = "MEGAPETS";
        cost = 20;
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = powerupName + " Cost: " + cost;
    }

    public override void MakeNumberGoUp()
    {
        gameManager.clickValue *= 2;
        gameManager.kittiesKlicked -= cost;
        cost *= 4;
    }

    public override IEnumerator ShowTutorialText()
    {
        tutorialText.SetActive(true);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        tutorialText.SetActive(false);
    }

    protected override bool IsFirstButtonPressed()
    {
        if (cost == 20)
        {
            firstTimePressed = true;
        }
        else
        {
            firstTimePressed = false;
        }
        return firstTimePressed;
    }
}
