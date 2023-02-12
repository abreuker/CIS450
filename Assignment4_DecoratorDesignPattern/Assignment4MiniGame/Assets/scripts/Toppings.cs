using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Toppings.cs
 * Assignment 4 - Decorator Pattern
 * I believe this is technically the component script of 
 * the decorator pattern. It's the base of all the topping decorations. 
 */

[System.Serializable]
public class Toppings 
{
    [field: SerializeField] public virtual float scoreValue { set; get; } = 0f;

    [field: SerializeField] public virtual bool hasSausage { set; get; } = false;

    [field: SerializeField] public virtual bool hasMush { set; get; } = false;

    [field: SerializeField] public virtual bool hasPep { set; get; } = false;

    [field: SerializeField] public virtual bool hasPinap { set; get; } = false;

    [field: SerializeField] public virtual bool hasHam { set; get; } = false;

    [field: SerializeField] public virtual bool hasCheese { set; get; } = false;

    [field: SerializeField] public virtual bool hasSauce{ set; get; } = false;
}
