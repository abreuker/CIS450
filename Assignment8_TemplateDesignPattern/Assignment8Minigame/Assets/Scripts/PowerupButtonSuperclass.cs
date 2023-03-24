using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PowerupButtonSuperclass : MonoBehaviour
{
    protected static bool firstTimePressed = true;
    protected bool buttonDown = false;
    protected bool isTimed;
    protected int cost;

    protected TextMeshProUGUI buttonText;
    protected string powerupName;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
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
            if (IsFirstButtonPressed())
            {
                StartCoroutine(ShowTutorialText());
                firstTimePressed = false;
            }
            
        }
        
    }

    protected bool IsFirstButtonPressed()
    {
        return firstTimePressed;
    }

    protected virtual bool IsTimedPowerup()
    {
        return isTimed;
    }

    public abstract IEnumerator ShowTutorialText();

    public abstract void MakeNumberGoUp();

}
