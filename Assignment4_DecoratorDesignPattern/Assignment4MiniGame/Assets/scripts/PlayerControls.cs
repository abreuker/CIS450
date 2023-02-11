using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Pizza pizza;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pizza = gameManager.activePizza;
    }

    public void AddTopping(string pizzaTopping)
    {
        switch (pizzaTopping)
        {
            default:
                pizza.ShowTopping(0);
                pizza.toppings = new ToppingSasauge(pizza.toppings);
                
                break;
        }
    }

    public void showCurrentPizzaScore()
    {
        Debug.Log(pizza.toppings.scoreValue);
    }
}
