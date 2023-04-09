using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PlayerController.cs
 * Assignment 10 - Singleton and Object Pooling Patterns
 * Code that allows the player to jump, roll, and die.
 */
public class PlayerController : MonoBehaviour
{
    public Vector2 jumpHeight;
    public float groundLevel;
    public Animator animator;
    public bool isRolling;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && gameObject.transform.position.y <= groundLevel)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
        if((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !isRolling && gameObject.transform.position.y <= groundLevel)
        {
            StartCoroutine(Roll());
        }

        if (gameObject.transform.position.y > groundLevel)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    public IEnumerator Roll()
    {
        isRolling = true;
        animator.SetBool("isRolling", true);
        yield return new WaitForSeconds(.5f);
        isRolling = false;
        animator.SetBool("isRolling", false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || (collision.CompareTag("TallObstacle") && !isRolling))
        {
            GameManager.instance.Lose();
        }
    }
}
