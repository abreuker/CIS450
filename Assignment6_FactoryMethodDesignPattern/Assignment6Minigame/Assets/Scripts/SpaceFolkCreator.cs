using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ASpaceFolkCreator.cs
 * Assignment 6 - Factory Method Pattern
 * Base for both enemy and ally creators
 */
public abstract class SpaceFolkCreator 
{
    public abstract GameObject CreatePrefab(string type);
    public abstract GameObject AddScript(GameObject prefab, string type);
}
