using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSasauge : ToppingDecorator
{
    public Toppings toppings;

    public ToppingSasauge(Toppings toppings)
    {
        this.toppings = toppings;
    }

    public override float scoreValue 
    {
        get { return toppings.scoreValue + 5; }
        set { scoreValue= value; }
    }

    public override bool hasSausage 
    {
        get { return true; }
        set { hasSausage = true; }
    }
    public override bool hasMush
    {
        get { return toppings.hasMush; }
        set { hasMush = toppings.hasMush; }
    }
    public override bool hasPep
    {
        get { return toppings.hasPep; }
        set { hasPep = toppings.hasPep; }
    }
    public override bool hasPinap
    {
        get { return toppings.hasPinap; }
        set { hasPinap = toppings.hasPinap; }
    }
}
