using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchYellow : BowlBehavior
{
    public override string Catch()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow; //change the color of the bowl.
        return "Banana"; //change the tag that the bowl will catch
    }
}
