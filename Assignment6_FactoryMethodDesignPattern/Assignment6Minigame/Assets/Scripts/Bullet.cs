using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Bullet.cs
 * Assignment 6 - Factory Method Pattern
 * Contains code for the player's bullets
 */
public class Bullet : MonoBehaviour
{
    public Vector2 holdVelocity;
    public bool holdVelocitySet;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the velocity of the bullet
        if (!holdVelocitySet)
        {
            holdVelocity = GetComponent<Rigidbody2D>().velocity;
            holdVelocitySet = true;
        }
        //making sure the game is active
        if (!gameManager.isGameActive)
        {

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = holdVelocity;
        }

    }

    //killing enemies and despawning when out of frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (collision.gameObject.GetComponent<SpaceFolk>() != null)
            {
                collision.gameObject.GetComponent<SpaceFolk>().Die();
            }
            else
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DespawnWall"))
        {
            Destroy(gameObject);
        }
    }


}