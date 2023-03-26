using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Autopets : PowerupButtonSuperclass
{
    public GameObject tutorialText;
    public float autoclickValue;
    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.FindGameObjectWithTag("AutopetText");
        tutorialText.SetActive(false);

        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        powerupName = "AUTOPETS";
        cost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = powerupName + " Cost: " + cost;
        gameManager.kittiesKlicked += autoclickValue;
    }

    public override void MakeNumberGoUp()
    {
        gameManager.autoClicksStarted = true;
        if (IsFirstButtonPressed())
        {
            autoclickValue += 0.01f;
        }
        else
        {
            autoclickValue *= 1.5f;
        }
        gameManager.kittiesKlicked -= cost;
        cost *= 2;
    }

    public override IEnumerator ShowTutorialText()
    {
        tutorialText.SetActive(true);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        tutorialText.SetActive(false);
    }

    protected override bool IsFirstButtonPressed()
    {
        if (cost == 10)
        {
            firstTimePressed = true;
        }
        else
        {
            firstTimePressed= false;
        }
        return firstTimePressed;
    }
}
