using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
 * Anna Breuker
 * HungryState.cs
 * Assignment 9 - State Pattern
 * State for the pet when it's hungry 
 * (only moves towards food, can't be pet, angry bark.)
 */
public class HungryState : PetState
{
    PetAIStateManager petAIStateManager;

    Animator animator;
    SpriteRenderer spriteRenderer;

    GameObject hungryBark;

    // Start is called before the first frame update
    void Start()
    {
        petAIStateManager = gameObject.GetComponent<PetAIStateManager>();
        hungryBark = GameObject.FindGameObjectWithTag("HungryBark");
        hungryBark.GetComponent<TextMeshProUGUI>().enabled = false;
        animator = GameObject.FindGameObjectWithTag("Pet").GetComponent<Animator>();
        spriteRenderer = GameObject.FindGameObjectWithTag("Pet").GetComponent<SpriteRenderer>();
    }

    public override void Bark()
    {
        StartCoroutine(ShowBark());
    }

    public IEnumerator ShowBark()
    {
        hungryBark.GetComponent<TextMeshProUGUI>().enabled = true;
        yield return new WaitForSeconds(2);
        hungryBark.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public override void BePetted()
    {
        //when petted but hungry, too hungry to be excited.
        Debug.Log("Is too hungry to be excited :(");
    }

    public override void Eat()
    {
        //when fed while hungry, goes back to idle state.
        Debug.Log("Ate while Hungry.");
        petAIStateManager.currentState = petAIStateManager.idleState;
    }

    public override void Move()
    {
        GameObject nearestFood = GameObject.FindGameObjectWithTag("Food");

        if (nearestFood == null)
        {
            transform.position += Vector3.zero;
            animator.SetBool("isMoving", false);
        }
        else if (nearestFood.transform.position.x > transform.position.x)
        {
            transform.position += Vector3.right * Time.deltaTime * 3;
            animator.SetBool("isMoving", true);
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * 3;
            animator.SetBool("isMoving", true);
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
