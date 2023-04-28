using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * FruitBasket.cs
 * Assignment 12 - Composite Pattern
 * This is the code for a basket inside the inventory that holds its own number of inventory leaves.
 */
public class FruitBasket : InventoryItem
{
    public List<InventoryItem> fruits = new List<InventoryItem>();
    public override int CalculatePointValue()
    {
        int totalPoints = 0;
        for (int i = 0; i < fruits.Count; i++)
        {
            Debug.Log(i + "  point value: " + fruits[i].CalculatePointValue());
            totalPoints += fruits[i].CalculatePointValue();
        }
        return totalPoints;
    }

    public override FruitType GetFruitType()
    {
        return fruitType;
    }

    public override InventoryItem GetChildItem(int i)
    {
        return fruits[i];
    }

    public override void Add(InventoryItem item)
    {
        fruits.Add(item);
    }

    public override void Remove(InventoryItem item) 
    { 
        fruits.Remove(item);
    }
}
