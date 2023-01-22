using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Townsfolk.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains the implemented code for townsfolk
 */
public class Townsfolk : NPC, IFriendly
{
    private string dialogue;

    //constructors
    public Townsfolk()
    {
        this.health = 1;
        this.dialogue = "Hello! I am a Townsfolk and I am saying words!";
    }

    public Townsfolk(float health, string dialogue)
    {
        this.health = health;
        this.dialogue = dialogue;
    }

    //abstract methods needed to be implemented
    public override void Die()
    {
        Debug.Log("A Townsfolk has died!");
    }

    public void Talk()
    {
        Debug.Log("A Townsfolk is talking! They say: \"" + dialogue + "\"");
    }

}
