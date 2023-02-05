using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * IObserver.cs
 * Assignment 3 - Observer Pattern
 * This interface provides the method headers for observer classes.
 */
public interface IObserver
{
    public void UpdateSelf(Vector2 playerPos, bool playerBarking);
}
