using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Anna Breuker
 * Customer.cs
 * Assignment 4 - Decorator Pattern
 * This class holds the behavior and variables for the customers. 
 */
public class CustomerBehavior : MonoBehaviour
{
    //general variables
    public GameManager gameManager;
    public Rigidbody2D body;

    //variables related to pizza orders.
    public GameObject pizzaOrderSprite;
    public GameObject pizzaOrderBox;
    public SpriteRenderer pizzaOrderSpriteRenderer;
    public Sprite[] pizzaOrderImages;
    public string[] pizzaOrderNames;
    public string pizzaOrderName;
    public int pizzaOrderNum;

    //variables needed for the customer emotes
    public Sprite[] customerEmotes;
    public SpriteRenderer customerRenderer;

    //variable which shows which customer is clicked on.
    public GameObject customerActiveOutline;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        pizzaOrderSpriteRenderer = pizzaOrderSprite.GetComponent<SpriteRenderer>();
        pizzaOrderNum = Random.Range(0, pizzaOrderNames.Length);
        pizzaOrderName = pizzaOrderNames[pizzaOrderNum];
        pizzaOrderSpriteRenderer.sprite = pizzaOrderImages[pizzaOrderNum];
        Debug.Log(pizzaOrderName);

        customerRenderer = GetComponent<SpriteRenderer>();
        customerRenderer.sprite = customerEmotes[0];

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.activeCustomer != this)
        {
            pizzaOrderBox.SetActive(false);
            customerActiveOutline.SetActive(false);
        }
    }

    //code to check if a pizza is correct for this specific customer.
    public bool IsPizzaCorrect(Pizza pizza) 
    {
        if (pizza != null)
        {
            Debug.Log("active pizza topping status:\nSauce: " + gameManager.activePizza.toppings.hasSauce
                + " Cheese: " + gameManager.activePizza.toppings.hasCheese
                + " Sausage: " + gameManager.activePizza.toppings.hasSausage
                + " Pep: " + gameManager.activePizza.toppings.hasPep
                + " Pinap: " + gameManager.activePizza.toppings.hasPinap
                + " Ham: " + gameManager.activePizza.toppings.hasHam
                + " Mush: " + gameManager.activePizza.toppings.hasMush);
            //i apologize in advance for how spghetti this is going to get. 
            if (pizzaOrderNum == 0) //all
            {
                //if (gameManager.activePizza.toppings.hasSausage) ;
                if (gameManager.activePizza.isCooked
                    && gameManager.activePizza.toppings.hasSauce
                    && gameManager.activePizza.toppings.hasCheese
                    && gameManager.activePizza.toppings.hasSausage
                    && gameManager.activePizza.toppings.hasPep
                    && gameManager.activePizza.toppings.hasPinap
                    && gameManager.activePizza.toppings.hasHam
                    && gameManager.activePizza.toppings.hasMush)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pizzaOrderNum == 1) //pinaple and ham
            {
                if (gameManager.activePizza.isCooked
                    && gameManager.activePizza.toppings.hasSauce
                    && gameManager.activePizza.toppings.hasCheese
                    && !gameManager.activePizza.toppings.hasSausage
                    && !gameManager.activePizza.toppings.hasPep
                    && gameManager.activePizza.toppings.hasPinap
                    && gameManager.activePizza.toppings.hasHam
                    && !gameManager.activePizza.toppings.hasMush)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pizzaOrderNum == 2) //all but pinaple
            {
                if (gameManager.activePizza.isCooked
                    && gameManager.activePizza.toppings.hasSauce
                    && gameManager.activePizza.toppings.hasCheese
                    && gameManager.activePizza.toppings.hasSausage
                    && gameManager.activePizza.toppings.hasPep
                    && !gameManager.activePizza.toppings.hasPinap
                    && gameManager.activePizza.toppings.hasHam
                    && gameManager.activePizza.toppings.hasMush)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pizzaOrderNum == 3) //sausage and mushroom
            {
                if (gameManager.activePizza.isCooked
                    && gameManager.activePizza.toppings.hasSauce
                    && gameManager.activePizza.toppings.hasCheese
                    && gameManager.activePizza.toppings.hasSausage
                    && !gameManager.activePizza.toppings.hasPep
                    && !gameManager.activePizza.toppings.hasPinap
                    && !gameManager.activePizza.toppings.hasHam
                    && gameManager.activePizza.toppings.hasMush)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pizzaOrderNum == 4) //sausage and peporoni
            {
                if (gameManager.activePizza.isCooked
                    && gameManager.activePizza.toppings.hasSauce
                    && gameManager.activePizza.toppings.hasCheese
                    && gameManager.activePizza.toppings.hasSausage
                    && gameManager.activePizza.toppings.hasPep
                    && !gameManager.activePizza.toppings.hasPinap
                    && !gameManager.activePizza.toppings.hasHam
                    && !gameManager.activePizza.toppings.hasMush)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //sends the customer off screen (to be deleted)
    public void LeaveScene()
    {
        pizzaOrderBox.SetActive(false);
        customerActiveOutline.SetActive(false);
        body.AddForce(Vector2.left * .05f); 
    }

    //for when the player clicks on the customer
    private void OnMouseDown()
    {
        gameManager.activeCustomer= this;
        pizzaOrderBox.SetActive(true);
        customerActiveOutline.SetActive(true);
    }

    //specifically for despawning the customer when they are no longer needed.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DespawnZone"))
        {
            Destroy(gameObject);
        }
    }
}
