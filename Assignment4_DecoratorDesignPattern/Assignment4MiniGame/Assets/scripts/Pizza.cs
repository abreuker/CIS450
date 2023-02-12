using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
/*
 * Anna Breuker
 * Pizza.cs
 * Assignment 4 - Decorator Pattern
 * I believe this is technically the concrete component script
 * for the decorator pattern. It contains a Toppings object which
 * is referenced by other scripts through Pizza.toppings.[insert something here]
 * 
 * Generally this script contains the code needed for the pizza to funciton.
 */
public class Pizza : MonoBehaviour
{

    public GameManager gameManager;
    
    public GameObject[] toppingsObjects;
    public Toppings toppings;
    
    public bool isCooked;

    public GameObject pizzaActiveOutline;

    public Pizza pizzaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Debug.Log(toppingsObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.activePizza != this)
        {
            this.pizzaActiveOutline.SetActive(false);
        }
    }

    //code for showin the toppings visually
    public void ShowTopping(int toppingNum)
    {
        toppingsObjects[toppingNum].SetActive(true);
    }

    //code for selecting the pizza on click.
    public void OnMouseDown()
    {
        gameManager.activePizza = this;
        pizzaActiveOutline.SetActive(true);
    }

}
