using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
 * Anna Breuker
 * PowerupButtonSuperclass.cs
 * Assignment 8 - Template Pattern
 * The template superclass that contains the general "ActivatePowerup()" class.
 */
public abstract class PowerupButtonSuperclass : MonoBehaviour
{
    protected static bool firstTimePressed = true;
    protected bool buttonDown = false;
    protected int cost;

    protected TextMeshProUGUI buttonText;
    protected string powerupName;

    public GameManager gameManager;

    private void Start()
    {
        firstTimePressed = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePowerup()
    {
        if (gameManager.kittiesKlicked >= cost)
        {
            MakeNumberGoUp();
            StartCoroutine(ShowTutorialText()); 
        }   
    }

    protected virtual bool IsFirstButtonPressed()
    {
        return firstTimePressed;
    }

    public abstract IEnumerator ShowTutorialText();

    public abstract void MakeNumberGoUp();

}
