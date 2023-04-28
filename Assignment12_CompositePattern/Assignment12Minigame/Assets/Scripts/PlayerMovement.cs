using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Anna Breuker
 * PlayerMovement.cs
 * Assignment 12 - Composite Pattern
 * This is the code controls the movement of the player.
 */
public class PlayerMovement : MonoBehaviour
{
    //basic variables.
    public Rigidbody2D body;

    //movement variables
    public float horizontal;
    public float vertical;
    public float moveLimiter = 0.7f;

    public float runSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //calculate movement
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);


    }
}
