using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * CatchYellow.cs
 * Assignment 2 - Strategy Pattern
 * This class extends BowlBehavior and contains code for the bowl to be 
 * able to catch bananas.
 */
public class CatchYellow : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow; //change the color of the bowl.
        return "Banana"; //change the tag that the bowl will catch
    }
}
