using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * EnemyShip.cs
 * Assignment 6 - Factory Method Pattern
 * Code for the enemy ship.
 */
public class EnemyShip : SpaceFolk
{
    public GameObject bullet;
    public float shootSpeed;
    public float shootTime;
    public float maxYPos;
    public override void Die()
    {
        gameManager.score += (int)scoreValue;
        Destroy(gameObject);
    }

    public override void Move()
    {
        //horizontal movement
        if (transform.position.y > maxYPos)
        {
            body.velocity = Vector2.down * speed;
        }
        else if (transform.position.y < -maxYPos)
        { body.velocity = Vector2.up * speed; }
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
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * shootSpeed;
        }
    }
}
