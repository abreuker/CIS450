using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
 * Anna Breuker
 * Platform.cs
 * Assignment 11 - Facade Pattern
 * Code that manages the position and movement of both the platform and your guy.
 */
public class Platform : MonoBehaviour
{
    public Facade facade;

    public float speed;
    public float goalPos;
    public Animator convayorAnimator;

    public ParticleSystem confetti;
    // Start is called before the first frame update
    void Start()
    {
        convayorAnimator = GameObject.FindGameObjectWithTag("convayor").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (gameObject.transform.position.x < -15)
        {
            convayorAnimator.speed = 0;
            facade.ResetEverything();
        }
    }

    public void Move()
    {
        if (gameObject.transform.position.x > goalPos)
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            convayorAnimator.speed = 1;
        }
        else
        { 
            convayorAnimator.speed = 0;
        }
    }

    public void Done()
    {
        goalPos = -20;
        confetti.Play();
    }

    public void ResetPlatform()
    { 
        gameObject.transform.position = new Vector3(10, 0, 0);
        goalPos = 0;
    }

}
