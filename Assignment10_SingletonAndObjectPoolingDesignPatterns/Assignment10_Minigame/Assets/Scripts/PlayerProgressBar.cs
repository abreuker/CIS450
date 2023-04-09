using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * PlayerProgressBar.cs
 * Assignment 10 - Singleton and Object Pooling Patterns
 * Code for player's progress bar.
 */
public class PlayerProgressBar : MonoBehaviour
{
    public Image frogImage;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gamePaused)
        {
            frogImage.GetComponent<RectTransform>().anchoredPosition += new Vector2( Time.deltaTime * GameManager.instance.playerSpeed, 0);
        }
    }
}
