using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * EnemyBullet.cs
 * Assignment 5 - Simple Factory Pattern
 * Contains code for the enemy's bullets
 */
public class EnemyBullet : MonoBehaviour
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
        //set velocity of the bullet
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //killing the player and despawning when out of frame
        if (collision.gameObject.CompareTag("Player"))
        {

            gameManager.GameOver();
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ally") && !gameObject.CompareTag("Ally"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DespawnWall") || collision.gameObject.CompareTag("EnemyDespawnWall"))
        {
            Destroy(gameObject);
        }
    }
}
