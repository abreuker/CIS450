using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D body;

    public GameObject pizzaOrderSprite;
    public GameObject pizzaOrderBox;
    public SpriteRenderer pizzaOrderSpriteRenderer;
    public Sprite[] pizzaOrderImages;
    public string[] pizzaOrderNames;
    public string pizzaOrderName;
    public int pizzaOrderNum;

    public Sprite[] customerEmotes;
    public SpriteRenderer customerRenderer;

    public GameObject customerActiveOutline;

    //ok. need to have this set up so depending on the random order the requirements to get points for the pizza are different.
    //also need to have it in the design pattern so that when the toppings are added to a pizza they are worth more points.
    //might... might just go easy mode this time i'm having trouble thinking of how this'd be a full minigame without a Ton of work being put in. 

    

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

    public bool IsPizzaCorrect(Pizza pizza) 
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

    public void LeaveScene()
    {
        pizzaOrderBox.SetActive(false);
        customerActiveOutline.SetActive(false);
        body.AddForce(Vector2.left * .05f); 
    }

    private void OnMouseDown()
    {
        gameManager.activeCustomer= this;
        pizzaOrderBox.SetActive(true);
        customerActiveOutline.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
