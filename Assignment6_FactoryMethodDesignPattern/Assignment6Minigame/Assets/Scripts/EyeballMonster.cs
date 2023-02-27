using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * EyeballMonster.cs
 * Assignment 6 - Factory Method Pattern
 * Code for eyeball monsters.
 */
public class EyeballMonster : SpaceFolk
{
    public GameObject bullet;
    public Vector2[] shootDirections = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    public float shootSpeed;
    public float maxYPos;

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
        if (transform.position.y > maxYPos)
        {
            Debug.Log("going down");
            body.velocity = new Vector2(-0.5f,-1) * speed;
        }
        else if (transform.position.y < -maxYPos)
        {
            Debug.Log("going up");
            body.velocity = new Vector2(-0.5f, 1) * speed; 
        }
    }

    public override void Shoot()
    {
        //eyeball does not shoot
    }
}
