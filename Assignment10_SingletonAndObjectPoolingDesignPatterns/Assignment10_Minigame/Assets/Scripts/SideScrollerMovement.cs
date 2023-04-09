using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * SideScrollerMovement.cs
 * Assignment 10 - Singleton and Object Pooling Patterns
 * Code for obstacles to be able to move.
 */
public class SideScrollerMovement : MonoBehaviour
{
    public float obstacleBoundary;
    public string poolerTag;

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.gamePaused)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * GameManager.instance.sideScrollerSpeed;
        }
        if (gameObject.transform.position.x < obstacleBoundary || GameManager.instance.gamePaused)
        {
            ObjectPooler.instance.ReturnObjectToPool(poolerTag, gameObject);
        }
    }
}
