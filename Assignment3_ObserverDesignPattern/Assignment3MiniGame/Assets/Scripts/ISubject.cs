using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ISubject.cs
 * Assignment 3 - Observer Pattern
 * This interface provides the method headers for subject classes.
 */
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
//testasldjkfhaksjdfhlasdkjfhljfdkhjsdfa hjklasdfhlsflahjkasdfhjklasdfhjkl
