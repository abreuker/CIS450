using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchRed : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = Color.red; //change the color of the bowl.
        return "Apple"; //change the tag that the bowl will catch
    }
}
