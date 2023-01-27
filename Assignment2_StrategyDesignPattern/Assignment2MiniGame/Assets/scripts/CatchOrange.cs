using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchOrange : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = new Color (1.0f, 0.64f, 0.0f); //change the color of the bowl.
        return "Orange"; //change the tag that the bowl will catch
    }
}
