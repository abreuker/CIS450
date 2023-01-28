using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * CatchRed.cs
 * Assignment 2 - Strategy Pattern
 * This class extends BowlBehavior and contains code for the bowl to be 
 * able to catch apples.
 */
public class CatchRed : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = Color.red; //change the color of the bowl.
        return "Apple"; //change the tag that the bowl will catch
    }
}
