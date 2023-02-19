using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * EnemyShip.cs
 * Assignment 5 - Simple Factory Pattern
 * Code for the enemy ship.
 */
public class EnemyShip : Enemy
{
    public GameObject bullet;
    public float shootSpeed;
    public float shootTime;
    public float maxXPos;
    public override void Die()
    {
        gameManager.score += (int)scoreValue;
        Destroy(gameObject);
    }

    public override void Move()
    {
        //horizontal movement
        if (transform.position.x > maxXPos)
        {
            body.velocity = Vector2.left * speed;
        }
        else if (transform.position.x < -maxXPos)
        { body.velocity = Vector2.right * speed; }
    }

    public override void Shoot()
    {
        StartCoroutine(Fire());
    }

    protected IEnumerator Fire() 
    {
        //shoots bullets straight down
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * shootSpeed;
        }
    }
}
