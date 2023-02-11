using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingMush : ToppingDecorator
{
    public Toppings toppings;
    public ToppingMush(Toppings toppings)
    {
        this.toppings = toppings;
    }

    public override float scoreValue
    {
        get { return toppings.scoreValue + 5; }
        set { scoreValue = value; }
    }

    public override bool hasSausage
    {
        get { return toppings.hasSausage; }
        set { hasSausage = toppings.hasSausage; }
    }
    public override bool hasMush
    {
        get { return true; }
        set { hasMush = true; }
    }
    public override bool hasPep
    {
        get { return toppings.hasPep; }
        set { hasHam = toppings.hasPep; }
    }
    public override bool hasPinap
    {
        get { return toppings.hasPinap; }
        set { hasPinap = toppings.hasPinap; }
    }

    public override bool hasHam
    {
        get { return toppings.hasHam; }
        set { hasHam = toppings.hasHam; }
    }

    public override bool hasCheese
    {
        get { return toppings.hasCheese; }
        set { hasCheese = toppings.hasCheese; }
    }

    public override bool hasSauce
    {
        get { return toppings.hasSauce; }
        set { hasSauce = toppings.hasSauce; }
    }
}
