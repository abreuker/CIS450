using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShipShotgun : SpaceFolk
{
    public GameObject bullet;
    public Vector2[] shootDirections = {Vector2.right};
    public float shootSpeed;
    public float shootTime;
    public float maxYPos;
    public override void Die()
    {
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
        //shoots bullets in a shotgun range
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            for (int i = 0; i < shootDirections.Length; i++)
            {
                GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity = shootDirections[i] * shootSpeed;
            }
        }
    }
}
