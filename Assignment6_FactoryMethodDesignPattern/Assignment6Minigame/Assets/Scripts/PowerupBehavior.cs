using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject powerupSprite;
    public float speed;
    public float rotationSpeed;
    public string spaceFolkToSpawn;
    public bool isAlly;
    public SpaceFolkSpawner spaceFolkSpawner;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spaceFolkSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpaceFolkSpawner>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() //same movement as tentacle
    {
        if (gameManager.isGameActive)
        {
            body.velocity = Vector2.left * speed;
            powerupSprite.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isAlly) //spawn one ally when collecting a good powerup
            {
                spaceFolkSpawner.spaceFolkCreator = new AllyCreator();
                spaceFolkSpawner.SpawnSpaceFolk(spaceFolkToSpawn);
                Destroy(gameObject);
            }
            else //spawn two enemies when collecting a bad powerup
            {
                spaceFolkSpawner.spaceFolkCreator = new EnemyCreator();
                //yes i know i could've used a for loop here. octopath 2 came out this weekend. we're cutting corners.
                spaceFolkSpawner.SpawnSpaceFolk(spaceFolkToSpawn);
                spaceFolkSpawner.SpawnSpaceFolk(spaceFolkToSpawn);
                Destroy(gameObject);
            }
        }
    }
}
