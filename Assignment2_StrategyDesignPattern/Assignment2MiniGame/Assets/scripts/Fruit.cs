using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D body;
    public float xRange;
    public float yRange;
    public float ySpawnPos;

    private PlayerMovement player;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Bowl").GetComponent<PlayerMovement>();
        body = GetComponent<Rigidbody2D>();
        transform.position = RandomSpawnPos();
    }

    private Vector2 RandomSpawnPos()
    {
        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.CompareTag(player.tagAccepted));
        if (other.CompareTag("Bowl") && gameObject.CompareTag(player.tagAccepted))
        {
            Debug.Log("fruit catch! nice job!");
            gameManager.score++;
            player.fruitCollected.Play();
            if (gameManager.score >= 30 || (gameManager.tutorialActive == true && gameManager.score >= 5))
            {
                player.winSound.Play();
            }
            Destroy(gameObject);
        }
        else if(other.CompareTag("DeathZone"))
        {
            Debug.Log("fruit fell!!!!");
            if (!gameManager.tutorialActive && gameManager.isGameActive)
            {
                gameManager.GameOver();
                player.fruitDropped.Play();
            }
            Destroy(gameObject);
        }
    }
}
