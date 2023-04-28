using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Spawner.cs
 * Assignment 12 - Composite Pattern
 * This class is responsible for spawning in the collectable items.
 */
public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float xRange;
    public float yRange;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[index], new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0), Quaternion.identity);
        }
    }
}
