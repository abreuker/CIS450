using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
 * Anna Breuker
 * FloatingTentacle.cs
 * Assignment 6 - Factory Method Pattern
 * Code for the floating tentacles.
 */
public class FloatingTentacle : SpaceFolk
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
        //moves straight towards the player, rotating, as if floating through space
        body.velocity = Vector2.left * speed;
        tentacleSprite.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);
    }

    public override void Shoot()
    {
        //tentacle doesn't shoot
    }
}
