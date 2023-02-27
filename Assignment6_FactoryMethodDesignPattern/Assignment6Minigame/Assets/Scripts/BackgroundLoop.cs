using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * Background.cs
 * Assignment 6 - Factory Method Pattern
 * Code for the scrolling background.
 */
public class BackgroundLoop : MonoBehaviour
{
    public float speed;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -17.8f)
        {
            transform.position = startPos;
        }
    }
}
