using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PetHunger.cs
 * Assignment 9 - State Pattern
 * Script that manages the pet's hunger (and the ability to pet it.)
 */
public class PetHunger : MonoBehaviour
{
    public float hunger;
    public float hungerRate;
    public ProgressBar hungerBar;

    public PetAIStateManager petAIStateManager;
    // Start is called before the first frame update
    void Start()
    {
        hunger = 100;
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime * hungerRate;
        hungerBar.current = hunger;

        //could technically manage this in another script but it works just fine here.
        //detectes when the player pets the pet.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform)
            {
                Debug.Log("Pet button pushed");
                petAIStateManager.BePetted();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (hunger < 100)
            {
                hunger += 25;
            }
            petAIStateManager.Eat();
            Destroy(collision.gameObject);
        }
    }
}
