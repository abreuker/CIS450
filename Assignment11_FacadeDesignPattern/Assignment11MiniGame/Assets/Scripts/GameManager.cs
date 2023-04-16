using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * GameManager
 * Assignment 11 - Facade Pattern
 * Code that manages specifically the how to play screen.
 */
public class GameManager : MonoBehaviour
{
    public GameObject howToPlayScreen;

    public void howToPlay()
    {
        if (howToPlayScreen.activeInHierarchy)
        {
            howToPlayScreen.SetActive(false);
        }
        else
        {
            howToPlayScreen.SetActive(true);
        }
    }
}
