using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        body.velocity = Vector2.down * speed;
        tentacleSprite.transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime, Space.World);
    }

    public override void Shoot()
    {

    }
}
