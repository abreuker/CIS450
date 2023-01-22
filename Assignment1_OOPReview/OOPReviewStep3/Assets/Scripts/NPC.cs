using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * NPC.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains an abstract class for any NPC.
 */
public abstract class NPC 
{
    public float health;
    //all NPCs die, how it is implemented changes for the individual subclasses.
    public abstract void Die();

    //all NPCs can be attacked in the same way.
    public float BeAttacked(float damage)
    {
        health--;
        Debug.Log("An NPC has taken damage! It now has " + (health) + " health!");
        if (health <= 0)
        {
            this.Die();
        }
        return health;
    }
}
