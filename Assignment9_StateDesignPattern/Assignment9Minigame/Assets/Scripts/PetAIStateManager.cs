using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currentState = idleState;
    }

    public void MoveToRandomDirection() { currentState.MoveToRandomDirection(); }
    public void Bark() { currentState.Bark(); }
    public void Eat() { currentState.Eat(); }
    public void BePetted() { currentState.BePetted(); }

}
