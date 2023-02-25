using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * SpaceFolk.cs
 * Assignment 5 - Simple Factory Pattern
 * Contains the abstract code for all enemies along with all shared behaviors.
 */
public abstract class SpaceFolk : MonoBehaviour
{
    public float scoreValue;
    public float speed;
    public Rigidbody2D body;

    public GameManager gameManager;

    public void Start()
    {
        Shoot();
        body = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyDespawnWall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }

    public abstract void Move();
    public abstract void Die();

    public abstract void Shoot();
}
