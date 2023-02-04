using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a test to make sure that visual studio will not crash.,
public class PlayerMovement : MonoBehaviour, ISubject
{
    //player will notify the sheep and coyotes of where it's location is if it is barking.

    public Animator animator;
    public Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    public float horizontal;
    public float vertical;
    public float moveLimiter = 0.7f;

    public float runSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        if (Mathf.Abs(horizontal) <= 0.01)
        {
            animator.SetFloat("horizontal", Mathf.Abs(vertical));
        }

        if (horizontal > 0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (horizontal < -0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void RegisterObserver(IObserver observer)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveObserver(IObserver observer)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyObservers()
    {
        throw new System.NotImplementedException();
    }
}