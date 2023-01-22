using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Bandit.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains the implemented code for bandit
 */
public class Bandit : NPC, IHostile
{
    private float attackPower;

    //constructors
    public Bandit()
    {
        this.health = 1;
        this.attackPower = 1;
    }
    public Bandit(float health, float attackPower)
    {
        this.health = health;
        this.attackPower = attackPower;
    }

    //abstract methods needed to be implemented
    public void Attack()
    {
        Debug.Log("Bandit has attacked for " + attackPower + " points of damage!");
    }

    public override void Die()
    {
        Debug.Log("A Bandit has died!");
    }

}
