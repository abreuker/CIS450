using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Toppings 
{
    [field: SerializeField] public virtual float scoreValue { set; get; } = 0f;

    [field: SerializeField] public virtual bool hasSausage { set; get; } = false;

    [field: SerializeField] public virtual bool hasMush { set; get; } = false;

    [field: SerializeField] public virtual bool hasPep { set; get; } = false;

    [field: SerializeField] public virtual bool hasPinap { set; get; } = false;
}
