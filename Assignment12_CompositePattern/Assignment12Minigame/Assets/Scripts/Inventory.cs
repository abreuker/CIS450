using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
 * Anna Breuker
 * Inventory.cs
 * Assignment 12 - Composite Pattern
 * This is the overarching script for the inventory system. The 'client.'
 */
public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public GameObject orangeSquare;
    public GameObject appleSquare;
    public GameObject bananaSquare;
    public GameObject basketSquare;

    public int numOfOranges;
    public int numOfApples;
    public int numOfBananas;
    public int numOfBaskets;

    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orangeSquare.GetComponent<TextMeshProUGUI>().text = numOfOranges.ToString();
        appleSquare.GetComponent<TextMeshProUGUI>().text = numOfApples.ToString();
        bananaSquare.GetComponent<TextMeshProUGUI>().text = numOfBananas.ToString();
        basketSquare.GetComponent<TextMeshProUGUI>().text = numOfBaskets.ToString();

        scoreText.text = "Score: " + score.ToString();
    }

    public void addItemToInventory(InventoryItem item)
    {
        inventoryItems.Add(item);
        CalculateTotalPoints();
        if (item.GetFruitType() == InventoryItem.FruitType.Orange)
        {
            numOfOranges++;
        }
        else if (item.GetFruitType() == InventoryItem.FruitType.Apple)
        {
            numOfApples++;
        }
        else if (item.GetFruitType() == InventoryItem.FruitType.Banana)
        {
            numOfBananas++;
        }
        else
        { 
            numOfBaskets++;
        }
    }

    public void CalculateTotalPoints()
    {
        score = 0;
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Debug.Log(i + "point value: " + inventoryItems[i].CalculatePointValue());
            score += inventoryItems[i].CalculatePointValue();
        }
    }
}
