using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * AllyShip.cs
 * Assignment 6 - Factory Method Pattern
 * Code for the simple ally ship.
 */
public class AllyShip : SpaceFolk
{
    public GameObject bullet;
    public float shootSpeed;
    public float shootTime;
    public float maxYPos;
    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Move()
    {
        isAlly= true;
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
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shootSpeed;
        }
    }
}
