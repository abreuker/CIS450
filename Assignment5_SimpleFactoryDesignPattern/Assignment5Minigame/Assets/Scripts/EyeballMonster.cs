using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * EyeballMonster.cs
 * Assignment 5 - Simple Factory Pattern
 * Code for eyeball monsters.
 */
public class EyeballMonster : Enemy
{
    public GameObject bullet;
    public Vector2[] shootDirections = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    public float shootSpeed;
    public float maxXPos;

    public override void Die()
    {
        //upon death, explode into a circle of bullets
        gameManager.score += (int)scoreValue;
        for (int i = 0; i < shootDirections.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = shootDirections[i] * shootSpeed;
        }
        Destroy(gameObject);
    }

    public override void Move()
    {
        //move diagnolly across the sceen
        if (transform.position.x > maxXPos)
        { 
            body.velocity = new Vector2(1,0.5f)* speed;
        }
        else if( transform.position.x < -maxXPos)
        {  body.velocity = new Vector2(1, -0.5f) * speed; }
    }

    public override void Shoot()
    {
        //eyeball does not shoot
    }
}
