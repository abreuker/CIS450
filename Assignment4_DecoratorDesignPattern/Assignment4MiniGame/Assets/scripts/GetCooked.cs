using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * GetCooked.cs
 * Assignment 4 - Decorator Pattern
 * This simply switches the sprites for the pizza 
 * and toppings to their cooked varients when
 * the pizza is cooked. 
 */
public class GetCooked : MonoBehaviour
{
    public Pizza pizza;
    public Sprite uncookedSprite;
    public Sprite cookedSprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = uncookedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (pizza.isCooked)
        { 
            spriteRenderer.sprite = cookedSprite;
        }
    }
}
