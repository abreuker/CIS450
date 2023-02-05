using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Sheep.cs
 * Assignment 3 - Observer Pattern
 * This observer class provides the behaviors for the sheep entities.
 */
public class Sheep : MonoBehaviour, IObserver
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D body;

    public float horizontal;

    public GameManager gameManager;

    public PlayerMovement player;
    private Vector2 playerPos;
    private bool playerBarking;

    public float moveSpeed = 2;

    public float xRange;
    public float yRange;

    public float changeTimeLow = 1;
    public float changeTimeHigh = 4;

    private float changeTimeCount = 0;

    private Vector3 awayFromPlayer;
    private Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.forward, Vector3.back, Vector3.zero, Vector3.zero };
    public int currentMoveDirection;
    //sheep is going to move around based on player location and if the player barks.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();

        player.RegisterObserver(this);

        transform.position = RandomSpawnPos();
        gameManager.sheepPlural.Add(gameObject);
        Debug.Log("Sheep Sees: " + gameManager.sheepPlural);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (horizontal > 0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (horizontal < -0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    //update self with data from the player.
    public void UpdateSelf(Vector2 playerPos, bool playerBarking)
    {
        Debug.Log("Updating self (sheep)");
        this.playerPos = playerPos;
        this.playerBarking = playerBarking;
    }

    //code to move around.
    public void Move()
    {
        //body.constraints = RigidbodyConstraints2D.FreezePositionZ;
        Debug.Log(this.transform.position.z);
        if (gameManager.isGameActive)
        {
            //Debug.Log(Vector2.Distance((Vector3)playerPos, transform.position));
            if (Vector2.Distance((Vector3)playerPos, transform.position) > 3)
            {
                RandomMove();
                //Debug.Log("Moving Randomly");
            }
            else
            {
                awayFromPlayer = this.transform.position - (Vector3)playerPos;
                if (awayFromPlayer.x >= 0)
                {
                    horizontal = 1;
                }
                else
                {
                    horizontal = -1;
                }
                this.transform.position += awayFromPlayer * Time.deltaTime * moveSpeed;
                //Debug.Log("Should be moving away from Dog!");
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }

    //moving around randomly when out of range of player.
    public void RandomMove()
    {
        this.transform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;
        
        if (changeTimeCount > 0)
        {
            changeTimeCount -= Time.deltaTime;
        }
        else
        { 
            changeTimeCount = UnityEngine.Random.Range(changeTimeLow, changeTimeHigh);
            
            currentMoveDirection = Mathf.FloorToInt(UnityEngine.Random.Range(0, moveDirections.Length));
            if (currentMoveDirection == 0)
            {
                horizontal = 1;
            }
            else if (currentMoveDirection == 1)
            {
                horizontal = -1;
            }
        }
    }

    //manage where the sheep spawn
    private Vector2 RandomSpawnPos()
    {
        return new Vector2(UnityEngine.Random.Range(-xRange, xRange), UnityEngine.Random.Range(-yRange, yRange));
    }

    //code to kill the sheep and end the game.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DespawnWall"))
        {
            Debug.Log("Sheep went out of bounds");
            gameManager.GameOver();
            gameManager.sheepPlural.Remove(gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Coyote"))
        {
            Debug.Log("Coyote got a sheep :(");
            gameManager.GameOver();
            gameManager.sheepPlural.Remove(gameObject);
            Destroy(gameObject);
        }
        
    }
}
