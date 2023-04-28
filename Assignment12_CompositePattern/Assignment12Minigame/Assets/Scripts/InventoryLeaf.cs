using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * InventoryLeaf.cs
 * Assignment 12 - Composite Pattern
 * This is the code the inventory items at the end of the tree.
 */
public class InventoryLeaf : InventoryItem
{
    public int pointVal;

    public InventoryLeaf(FruitType fruitType)
    {
        this.fruitType = fruitType;
    }

    public override int GetAmount()
    {
        return pointVal;
    }

    public override FruitType GetFruitType()
    {
        return fruitType;
    }

    public override int CalculatePointValue()
    {
        if (fruitType == FruitType.Orange)
        {
            return 1;
        }
        else if (fruitType == FruitType.Apple)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    
}
