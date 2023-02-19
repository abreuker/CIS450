using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/*
 * Anna Breuker
 * SpawnManager.cs
 * Assignment 5 - Simple Factory Pattern
 * The spawn manager that calls on the simple enemy factory.
 */
public class SpawnManager : MonoBehaviour
{
    public SimpleEnemyFactory factory;

    private GameObject enemy;

    public Vector2 spawnPos;

    public GameManager gameManager;

    public string[] enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    //a way to call the coroutine from the game manager 
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    //the specific spawn enemy code needed for simple factory pattern
    public void SpawnEnemy(string enemyType)
    { 
        enemy = factory.CreateEnemy(enemyType);

        if (enemyType.Equals("Eyeball"))
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip == 0)
            {
                spawnPos = new Vector2(-8.6f, 6);
            }
            else
            {
                spawnPos = new Vector2(8.6f, 6);
            }
        }
        else if (enemyType.Equals("Tentacle"))
        {
            spawnPos = new Vector2(Random.Range(-8.5f, 8.5f), 6);
        }
        else if (enemyType.Equals("Ship"))
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip == 0)
            {
                spawnPos = new Vector2(10, Random.Range(-1.5f, 4.5f));
            }
            else
            {
                spawnPos = new Vector2(-10, Random.Range(-1.5f, 4.5f));

            }
        }
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }

    //spawning random enemies once the game starts
    protected IEnumerator SpawnEnemies()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(gameManager.spawnRate);
            int enemyNum = Random.Range(0, enemyTypes.Length);
            SpawnEnemy(enemyTypes[enemyNum]);
        }
    }
}
