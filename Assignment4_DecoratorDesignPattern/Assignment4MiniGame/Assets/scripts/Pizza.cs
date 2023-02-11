using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

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

    public void ShowTopping(int toppingNum)
    {
        toppingsObjects[toppingNum].SetActive(true);
    }

    public void OnMouseDown()
    {
        gameManager.activePizza = this;
        pizzaActiveOutline.SetActive(true);
    }

}
