using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PlayerMovement.cs
 * Assignment 3 - Observer Pattern
 * This subject class provides behaviors for the player and 
 * sends information to the sheep and coyote classes.
 */
public class PlayerMovement : MonoBehaviour, ISubject
{
    //basic variables.
    public Animator animator;
    public Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    //movement variables
    public float horizontal;
    public float vertical;
    public float moveLimiter = 0.7f;

    public float runSpeed = 3.0f;

    //subject variables
    public List<IObserver> observers = new List<IObserver>();
    public Vector2 currentPos;
    public bool isBarking;

    //variables specifically for the bark image.
    public GameObject bark1;
    public GameObject bark2;
    public GameObject barkPrefered;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(observers);
        
        //keep the current position prepared to send to observers.
        currentPos = transform.position;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //deal with the animator
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        if (Mathf.Abs(horizontal) <= 0.01)
        {
            animator.SetFloat("horizontal", Mathf.Abs(vertical));
        }

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0) 
        {
            NotifyObservers();
        }

        //flip the sprite when going left or right.
        if (horizontal > 0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
                barkPrefered = bark1;
            }
        }
        else if (horizontal < -0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
                barkPrefered = bark2;
            }
        }

        //calculate movement
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        //barking (scare away coyotes)
        if (Input.GetMouseButtonDown(0) && !isBarking)
        {
            isBarking = true;
            barkPrefered.SetActive(true);
            NotifyObservers();
        }
        else if (Input.GetMouseButtonUp(0) && isBarking)
        { 
            isBarking= false;
            bark1.SetActive(false);
            bark2.SetActive(false);
            NotifyObservers();
        }
    }

    //register observers
    public void RegisterObserver(IObserver observer)
    {
        //Debug.Log("Registering an Observer");
        observers.Add(observer);
    }

    //remove an observer 
    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    //update observers
    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateSelf(currentPos, isBarking);
        }
    }
}
