using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Fruit.cs
 * Assignment 2 - Strategy Pattern
 * This class contains the code for all of the fruit spawnable objects.
 */
public class Fruit : MonoBehaviour
{
    public float xRange;
    public float yRange;
    public float ySpawnPos;

    private PlayerMovement player;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //assign variables
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Bowl").GetComponent<PlayerMovement>();
        transform.position = RandomSpawnPos();
    }

    private Vector2 RandomSpawnPos()
    {
        //assign a random spawn position to each fruit
        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        //make sure that fruits don't fall after the game ends
        if (!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //the correct fruit being caught causes the score to increase
        if (other.CompareTag("Bowl") && gameObject.CompareTag(player.tagAccepted))
        {
            //Debug.Log("fruit catch! nice job!");
            gameManager.score++;
            player.fruitCollected.Play();
            if (gameManager.score >= 30 || (gameManager.tutorialActive == true && gameManager.score >= 5))
            {
                player.winSound.Play();
            }
            Destroy(gameObject);
        }
        //otherwise, destroy the fruit once it gets off screen
        else if(other.CompareTag("DeathZone"))
        {
            //Debug.Log("fruit fell!!!!");

            //if the tutorial is active, don't penalize the player for missing a fruit.
            if (!gameManager.tutorialActive && gameManager.isGameActive)
            {
                gameManager.GameOver();
                player.fruitDropped.Play();
            }
            Destroy(gameObject);
        }
    }
}
