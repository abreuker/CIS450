using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * CatchOrange.cs
 * Assignment 2 - Strategy Pattern
 * This class extends BowlBehavior and contains code for the bowl to be 
 * able to catch oranges.
 */
public class CatchOrange : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = new Color (1.0f, 0.64f, 0.0f); //change the color of the bowl.
        return "Orange"; //change the tag that the bowl will catch
    }
}
