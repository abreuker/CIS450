using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PetState.cs
 * Assignment 9 - State Pattern
 * Abstract class for all pet states.
 */
public abstract class PetState : MonoBehaviour
{
    public abstract void Move();

    public abstract void Bark();

    public abstract void Eat();

    public abstract void BePetted();
}
