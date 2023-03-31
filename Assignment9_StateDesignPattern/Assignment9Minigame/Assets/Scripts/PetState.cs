using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetState : MonoBehaviour
{
    public abstract void MoveToRandomDirection();

    public abstract void Bark();

    public abstract void Eat();

    public abstract void BePetted();
}
