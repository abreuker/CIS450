using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
 * Anna Breuker
 * FloatingTentacle.cs
 * Assignment 5 - Simple Factory Pattern
 * Code for the floating tentacles.
 */
public class FloatingTentacle :  Enemy
{
    public GameObject tentacleSprite;
    public float rotationSpeed;

    public override void Die()
    {
        gameManager.score += (int)scoreValue;
        Destroy(gameObject);
    }

    public override void Move()
    {
        //moves straight down, rotating, as if floating through space
        body.velocity = Vector2.down * speed;
        tentacleSprite.transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime, Space.World);
    }

    public override void Shoot()
    {
        //tentacle doesn't shoot
    }
}
