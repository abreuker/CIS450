using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ToppingDecorator.cs
 * Assignment 4 - Decorator Pattern
 * Decorator class, contains the variables all toppings need. 
 */
public abstract class ToppingDecorator : Toppings
{
    public override abstract float scoreValue { get; set; }

    public override abstract bool hasSausage { get; set; }

    public override abstract bool hasMush { get; set; }

    public override abstract bool hasPep { get; set; }

    public override abstract bool hasPinap { get; set; }

    public override abstract bool hasHam { get; set; }

    public override abstract bool hasCheese { get; set; }

    public override abstract bool hasSauce { get; set; }
}
