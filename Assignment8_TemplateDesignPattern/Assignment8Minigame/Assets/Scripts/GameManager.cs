using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;
using Unity.VisualScripting;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 8 - Template Pattern
 * The game manager that stores tutorial info and tracks the score.
 */
public class GameManager : MonoBehaviour
{

    public float kittiesKlicked;
    public int clickValue;
    public TextMeshProUGUI score;
    public bool autoClicksStarted;

    public GameObject clickingText;
    public GameObject powerupText;
    
    // Start is called before the first frame update
    void Start()
    {
        clickValue = 1;
        autoClicksStarted= false;
        StartCoroutine(Tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Pets: " + (int)kittiesKlicked;
    }

    public void ClickerButton()
    { 
        //Debug.Log("Button pressed");
        kittiesKlicked += clickValue;
    }

    public IEnumerator Tutorial()
    {
        clickingText.SetActive(true);
        yield return new WaitUntil(() => kittiesKlicked > 0);
        clickingText.SetActive(false);
        powerupText.SetActive(true);
        yield return new WaitUntil(() => clickValue > 1 || autoClicksStarted);
        powerupText.SetActive(false);
    }
}
