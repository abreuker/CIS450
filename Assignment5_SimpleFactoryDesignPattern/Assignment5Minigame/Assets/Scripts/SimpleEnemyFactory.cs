using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * SimpleEnemyFactory.cs
 * Assignment 5 - Simple Factory Pattern
 * Code for the enemy factory.
 */
public class SimpleEnemyFactory : MonoBehaviour
{
    public GameObject EnemyShipPrefab;
    public GameObject EyeballMonsterPrefab;
    public GameObject FloatingTentaclePrefab;

    private GameObject enemyToSpawn;

    public GameObject CreateEnemy(string enemyType)
    {
        enemyToSpawn = null;
        if (enemyType.Equals("Ship"))
        {
            enemyToSpawn = EnemyShipPrefab;
        }
        else if (enemyType.Equals("Eyeball"))
        { 
            enemyToSpawn= EyeballMonsterPrefab;
        }
        else if (enemyType.Equals("Tentacle"))
        {
            enemyToSpawn = FloatingTentaclePrefab;
        }
        return enemyToSpawn;
    }
}
