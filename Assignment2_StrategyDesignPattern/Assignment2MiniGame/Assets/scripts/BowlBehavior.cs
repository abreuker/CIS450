using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BowlBehavior : MonoBehaviour
{
    /*Catch is supposed to make it so 1) you can only catch the fruit of
     * the color of your bowl and 2) the color of your bowl changes. gonna 
     * have to rewrite the signature i think...
     */

    public abstract string Catch();
}
