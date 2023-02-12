using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ToppingSauce.cs
 * Assignment 4 - Decorator Pattern
 * Concrete decorator, topping that adds to the score of the pizza and
 * changes hasSauce to true while preserving other bools. 
 */
public class ToppingSauce : ToppingDecorator
{
    //past topping
    public Toppings toppings;

    //constructor
    public ToppingSauce(Toppings toppings)
    {
        this.toppings = toppings;
    }

    public override float scoreValue
    {
        get { return toppings.scoreValue + 5; }
        set { scoreValue = value; }
    }

    public override bool hasSausage
    {
        get { return toppings.hasSausage; }
        set { hasSausage = toppings.hasSausage; }
    }
    public override bool hasMush
    {
        get { return toppings.hasMush; }
        set { hasMush = toppings.hasMush; }
    }
    public override bool hasPep
    {
        get { return toppings.hasPep; }
        set { hasPep = toppings.hasPep; }
    }
    public override bool hasPinap
    {
        get { return toppings.hasPinap; }
        set { hasPinap = toppings.hasPinap; }
    }

    public override bool hasHam
    {
        get { return toppings.hasHam; }
        set { hasHam = toppings.hasHam; }
    }

    public override bool hasCheese
    {
        get { return toppings.hasCheese; }
        set { hasCheese = toppings.hasCheese; }
    }

    public override bool hasSauce
    {
        get { return true; }
        set { hasSauce = true; }
    }
}
