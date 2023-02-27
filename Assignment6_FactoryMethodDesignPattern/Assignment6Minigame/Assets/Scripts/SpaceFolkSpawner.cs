using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFolkSpawner : MonoBehaviour
{
    public SpaceFolkCreator spaceFolkCreator;
    public bool creatorIsAlly;

    //this doesn't *have* to be handled here but i also have a random enemy spawn throughout the game
    public string[] enemyTypes = {"eyeball", "tentacle", "enemyShip" };

    //while powerups aren't technically "space folk" or npcs, it makes sense to me to put the enumerator in the spawner script
    public GameObject[] powerups;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spaceFolkCreator = new AllyCreator();
        creatorIsAlly= true;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void SpawnSpaceFolk(string type)
    {
        GameObject spaceFolk = null;

        spaceFolk = spaceFolkCreator.CreatePrefab(type);

        Vector2 spawnPos = new Vector2(0, 0);
        int coinFlip = Random.Range(0, 2);
        if (type.Equals("eyeball"))
        {
            if (coinFlip == 0)
            {
                spawnPos = new Vector2(8.7f, 5.1f);
            }
            else
            {
                spawnPos = new Vector2(8.7f, -5.1f);
            }
        }
        else if (type.Equals("normalShip") || type.Equals("shotgunShip"))
        {
            if (coinFlip == 0)
            {
                spawnPos = new Vector2(-8.2f, 5.1f);
            }
            else
            {
                spawnPos = new Vector2(-8.2f, -5.1f);
            }
        }
        else if (type.Equals("enemyShip"))
        {
            if (coinFlip == 0)
            {
                spawnPos = new Vector2(Random.Range(-2.5f, 8.5f), 5.1f);
            }
            else
            {
                spawnPos = new Vector2(Random.Range(-2.5f, 8.5f), -5.1f);
            }
        }
        else if (type.Equals("tentacle"))
        {
            spawnPos = new Vector2(8.7f, Random.Range(-4.8f, 4.8f));
        }
        GameObject spaceFolkInstance = Instantiate(spaceFolk, spawnPos, spaceFolk.transform.rotation);

        spaceFolkCreator.AddScript(spaceFolkInstance, type);
    }

    public void StartRandomSpawns()
    { 
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerups());
    }

    protected IEnumerator SpawnEnemies()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(gameManager.spawnRate);
            int enemyNum = Random.Range(0, enemyTypes.Length);
            spaceFolkCreator = new EnemyCreator();
            SpawnSpaceFolk(enemyTypes[enemyNum]);
        }
    }

    protected IEnumerator SpawnPowerups()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(5);
            int powerupNum = Random.Range(0, powerups.Length);
            Vector2 spawnPos = new Vector2(8.6f, Random.Range(-4.8f, 4.8f));
            Instantiate(powerups[powerupNum], spawnPos, powerups[powerupNum].transform.rotation);
        }
    }
}
