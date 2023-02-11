using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject[] toppingsObjects;
    public Toppings toppings;

    public float scoreValue;

    public bool beenCooked;

    public GameObject pizzaActiveOutline;

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
        Debug.Log(toppings.hasSausage);
        gameManager.activePizza = this;
        pizzaActiveOutline.SetActive(true);
    }

}
