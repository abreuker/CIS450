using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryState : PetState
{
    PetAIStateManager petAIStateManager;

    GameObject hungryBark;

    // Start is called before the first frame update
    void Start()
    {
        petAIStateManager = gameObject.GetComponent<PetAIStateManager>();
        hungryBark = GameObject.FindGameObjectWithTag("HungryBark");
    }

    public override void Bark()
    {
        StartCoroutine(ShowBark());
    }

    public IEnumerator ShowBark()
    {
        hungryBark.SetActive(true);
        yield return new WaitForSeconds(2);
        hungryBark.SetActive(false);
    }

    public override void BePetted()
    {
        //when petted but hungry, too hungry to be excited.
        Debug.Log("Is too hungry to be excited :(");
    }

    public override void Eat()
    {
        //when fed while not hunrgy, just gets excited about the food.
        petAIStateManager.currentState = petAIStateManager.idleState;
    }

    public override void MoveToRandomDirection()
    {
        Debug.Log("Is too hungry to move :(");
        transform.position = new Vector3(0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
