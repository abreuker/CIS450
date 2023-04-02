using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PetAIStateManager.cs
 * Assignment 9 - State Pattern
 * State manager for the Pet AI.
 */
public class PetAIStateManager : MonoBehaviour
{
    public PetState idleState { get; set; }
    public PetState hungryState { get; set; }
    public PetState excitedState { get; set; }
    public PetState currentState { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        idleState = gameObject.AddComponent<IdleState>();
        hungryState = gameObject.AddComponent<HungryState>();
        excitedState = gameObject.AddComponent<ExcitedState>();
        currentState = idleState;
    }

    public void Move() { currentState.Move(); }
    public void Bark() { currentState.Bark(); }
    public void Eat() { currentState.Eat(); }
    public void BePetted() { currentState.BePetted(); }

}
