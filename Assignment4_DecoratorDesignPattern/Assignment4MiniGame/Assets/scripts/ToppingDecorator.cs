using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingDecorator : Toppings
{
    public override abstract float scoreValue { get; set; }

    public override abstract bool hasSausage { get; set; }

    public override abstract bool hasMush { get; set; }

    public override abstract bool hasPep { get; set; }

    public override abstract bool hasPinap { get; set; }
}
