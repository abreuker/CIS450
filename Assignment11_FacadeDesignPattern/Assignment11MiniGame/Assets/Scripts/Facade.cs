using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Facade.cs
 * Assignment 11 - Facade Pattern
 * Facade that manages the different methods using the Platform, PartManager, and TextBlurb classes.
 */
public class Facade : MonoBehaviour
{
    public Platform platform;
    public PartManager partManager;
    public TextBlurb textBlurb;

    public void FinishGuy()
    {
        platform.Done();
        textBlurb.CompletedGuyText();
        StartCoroutine(partManager.ChangeHeadColor());
        StartCoroutine(partManager.ChangeTorsoColor());
        StartCoroutine(partManager.ChangeLegsColor());
    }

    public void ResetEverything()
    { 
        platform.ResetPlatform();
        partManager.ResetParts();
        textBlurb.DoneWithText();
    }

}
