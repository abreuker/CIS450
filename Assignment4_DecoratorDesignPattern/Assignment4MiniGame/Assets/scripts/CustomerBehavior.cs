using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject pizzaOrderSprite;
    public SpriteRenderer pizzaOrderSpriteRenderer;
    public Sprite[] pizzaOrderImages;
    public string[] pizzaOrderNames;

    public GameObject customerActiveOutline;

    //ok. need to have this set up so depending on the random order the requirements to get points for the pizza are different.
    //also need to have it in the design pattern so that when the toppings are added to a pizza they are worth more points.
    //might... might just go easy mode this time i'm having trouble thinking of how this'd be a full minigame without a Ton of work being put in. 

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        pizzaOrderSpriteRenderer = pizzaOrderSprite.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.activeCustomer != this)
        {
            customerActiveOutline.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        gameManager.activeCustomer= this;
        customerActiveOutline.SetActive(true);
    }
}
