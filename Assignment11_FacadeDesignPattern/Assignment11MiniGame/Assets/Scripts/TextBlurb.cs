using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.CodeAnalysis;
/*
 * Anna Breuker
 * TextBlurb.cs
 * Assignment 11 - Facade Pattern
 * Code that manages the small text blurb that appears after you finish a guy.
 */
public class TextBlurb : MonoBehaviour
{
    public GameObject theText;
    public TextMeshProUGUI flavorText;
    public string[] flavorTexts = new string[] {"look at that fancy lad!", "what a weird little guy!", "so colorfuL!", "wow!", "neato!"};

    public void CompletedGuyText()
    { 
        theText.SetActive(true);
        flavorText.text = flavorTexts[Random.Range(0, flavorTexts.Length)];
    }

    public void DoneWithText()
    { 
        theText.SetActive(false);
    }
}
