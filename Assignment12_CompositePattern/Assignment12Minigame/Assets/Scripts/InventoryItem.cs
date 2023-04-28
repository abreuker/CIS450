using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * InventoryItem
 * Assignment 12 - Composite Pattern
 * This is the abstract class that contains code for all inventory items.
 */
public abstract class InventoryItem : MonoBehaviour
{
    public Inventory inventory;

    public enum FruitType {Orange, Apple, Banana, Basket };
    public FruitType fruitType;
    // Start is called before the first frame update

    public abstract FruitType GetFruitType();

    public abstract int CalculatePointValue();

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public virtual void Add(InventoryItem item)
    {
        Debug.Log("oops forgot to implement add on this one");
    }

    public virtual void Remove(InventoryItem item) 
    {
        Debug.Log("oops forgot to implement remove on this one");
    }

    public virtual int GetAmount()
    {
        Debug.Log("oops forgot to implement get amount on this one");
        return 1;
    }

    public virtual InventoryItem GetChildItem(int i)
    {
        Debug.Log("oops forgot to implement get child item on this one");
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inventory.addItemToInventory(this);
        Destroy(gameObject);
    }

}
