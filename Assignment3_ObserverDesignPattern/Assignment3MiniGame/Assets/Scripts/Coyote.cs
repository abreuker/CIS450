using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Coyote.cs
 * Assignment 3 - Observer Pattern
 * This observer class provides the behaviors for the coyote enemies.
 */
public class Coyote : MonoBehaviour, IObserver
{
    SpriteRenderer spriteRenderer;

    public float horizontal;

    public GameManager gameManager;

    public PlayerMovement player;
    private Vector2 playerPos;
    private bool playerBarking;

    public float moveSpeed = 2;

    public float xRange;
    public float yRange;

    public Vector2 sheepPosition;

    private Vector3 awayFromPlayer;
    private Vector3 towardsSheep;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        player.RegisterObserver(this);

        transform.position = RandomSpawnPos();
        Debug.Log("Coyote sees: " + gameManager.sheepPlural);
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

    //updates self with data from player
    public void UpdateSelf(Vector2 playerPos, bool playerBarking)
    {
        Debug.Log("Updating self (coyote)");
        this.playerPos = playerPos;
        this.playerBarking = playerBarking;
    }

    //code to manage movement
    public void Move()
    {
        //body.constraints = RigidbodyConstraints2D.FreezePositionZ;
        Debug.Log(this.transform.position.z);
        if (gameManager.isGameActive)
        {
            //Debug.Log(Vector2.Distance((Vector3)playerPos, transform.position));
            if (Vector2.Distance((Vector3)playerPos, transform.position) > 5)
            {
                MoveTowardsSheep();
                //Debug.Log("Moving Randomly");
            }
            else if(playerBarking)
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

    //when out of range of player, move towards a sheep.
    public void MoveTowardsSheep()
    {
        sheepPosition = gameManager.sheepPlural[0].transform.position;
        towardsSheep = (Vector3)sheepPosition - this.transform.position;
        if (towardsSheep.x >= 0)
        {
            horizontal = 1;
        }
        else
        {
            horizontal = -1;
        }
        this.transform.position += towardsSheep * Time.deltaTime * moveSpeed;
    }

    //manages spawn position.
    private Vector2 RandomSpawnPos()
    {
        if (Random.value > .5f)
        {
            return new Vector2(Random.Range(-xRange, xRange), yRange);
        }
        else
        { 
            return new Vector2(Random.Range(-xRange, xRange), -yRange); 
        }
    }

    //kills coyote when they go out of bounds
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DespawnWall"))
        {
            Debug.Log("Coyote went out of bounds");
            Destroy(gameObject);
        }
    }
}
