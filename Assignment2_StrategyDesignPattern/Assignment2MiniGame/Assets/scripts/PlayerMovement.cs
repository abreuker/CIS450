using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PlayerMovement.cs
 * Assignment 2 - Strategy Pattern
 * This class controls the player movement and bowl behavior (strategy pattern).
 */
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float horizontal;
    public float moveLimiter = 0.7f;
    public float movementSpeed = 3f;

    public AudioSource fruitCollected;
    public AudioSource fruitDropped;
    public AudioSource winSound;

    public string tagAccepted;

    public BowlBehavior bowlBehavior;
    // Start is called before the first frame update
    void Start()
    {
        //assign variables
        body = GetComponent<Rigidbody2D>();
        bowlBehavior = gameObject.AddComponent<CatchYellow>();
    }

    // Update is called once per frame
    void Update()
    {
        //use bowl behavior to assign the accepted tag
        tagAccepted = bowlBehavior.Catch();

        //player movement
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * movementSpeed, 0);

        //changing the bowl behavior (and bowl color) through the strategy pattern.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchRed>();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchOrange>();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchYellow>();
        }
    }
}
