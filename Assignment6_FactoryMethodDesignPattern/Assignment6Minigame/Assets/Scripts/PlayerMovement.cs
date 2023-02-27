using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PlayerMovement.cs
 * Assignment 6 - Factory Method Pattern
 * This class provides behaviors for the player.
 */
public class PlayerMovement : MonoBehaviour
{
    //basic variables.
    public Rigidbody2D body;
    public GameManager gameManager;

    //movement variables
    public bool canMove;
    public float vertical;
    public float moveLimiter = 0.7f;

    public float runSpeed = 3.0f;
    public float shootSpeed = 50f;

    public GameObject bullet;
    float lastShootTime;
    float shootDelay = .1f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxis("Vertical");


            //calculate movement
            if (vertical != 0)
            {
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(0, vertical * runSpeed);
        

        //shoot bullets
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("button pressed");
            Debug.Log(lastShootTime + " " + Time.unscaledTime);
            if (lastShootTime + shootDelay < Time.unscaledTime)
            {
                lastShootTime = Time.unscaledTime;
                shootBullet();
            }
        }
        


    }

    void shootBullet()
    {
        Debug.Log("bullet firing");
        GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shootSpeed;
    }
}
