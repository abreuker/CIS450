using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * ProgressBar.cs
 * Assignment 9 - State Pattern
 * Code for the hunger bar.
 */
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public float current;
    public Image mask;
    //public Image fill;
    //public Color color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

        //fill.color = color;
    }
}