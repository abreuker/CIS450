using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Command.cs
 * Assignment 7 - Command Pattern
 * Interface for different commands.
 */
public interface Command
{
    void Execute();
    void Undo();
}
