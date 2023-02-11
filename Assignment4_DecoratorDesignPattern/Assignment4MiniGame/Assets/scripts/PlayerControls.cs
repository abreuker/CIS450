using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Pizza pizza;
    public GameObject pizzaPrefab;
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
        if (pizza != null)
        {
            switch (pizzaTopping)
            {
                case "sauce":
                    pizza.ShowTopping(0);
                    pizza.toppings = new ToppingSauce(pizza.toppings);
                    break;
                case "cheese":
                    pizza.ShowTopping(1);
                    pizza.toppings = new ToppingCheese(pizza.toppings);
                    break;
                case "sausage":
                    pizza.ShowTopping(2);
                    pizza.toppings = new ToppingSasauge(pizza.toppings);
                    break;
                case "pep":
                    pizza.ShowTopping(3);
                    pizza.toppings = new ToppingPep(pizza.toppings);
                    break;
                case "pinap":
                    pizza.ShowTopping(4);
                    pizza.toppings = new ToppingPinap(pizza.toppings);
                    break;
                case "ham":
                    pizza.ShowTopping(5);
                    pizza.toppings = new ToppingHam(pizza.toppings);
                    break;
                case "mush":
                    pizza.ShowTopping(6);
                    pizza.toppings = new ToppingMush(pizza.toppings);
                    break;
                default:
                    break;
            }
        }
    }

    public void CookPizza()
    {
        if (pizza != null)
        {
            pizza.isCooked = true;
        }
    }

    public void GivePizzaToCustomer()
    {
        Debug.Log(gameManager.activeCustomer.IsPizzaCorrect(gameManager.activePizza));
        if (gameManager.activeCustomer.IsPizzaCorrect(gameManager.activePizza))
        {
            gameManager.activeCustomer.customerRenderer.sprite = gameManager.activeCustomer.customerEmotes[1];
            gameManager.score += gameManager.activePizza.toppings.scoreValue;
        }
        else
        {
            gameManager.activeCustomer.customerRenderer.sprite = gameManager.activeCustomer.customerEmotes[2];
        }
        Instantiate(pizzaPrefab);
        Destroy(pizza.gameObject);
        gameManager.activeCustomer.LeaveScene();
    }

    public void TrashPizza()
    {
        Instantiate(pizzaPrefab);
        Destroy(pizza.gameObject);
    }
}
