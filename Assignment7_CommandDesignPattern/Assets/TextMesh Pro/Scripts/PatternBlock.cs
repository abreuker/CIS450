using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * PatternBlock.cs
 * Assignment 7 - Command Pattern
 * Code that manages the state of the clickable blocks
 * and runs the command for changing block color.
 */
public class PatternBlock : MonoBehaviour
{
    public GameManager gameManager;

    public CustomCursor cursor;
    public Image blockImage;

    private Command changeBlockColor;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
        blockImage = GetComponent<Image>();

        changeBlockColor = new ChangeBlockColor(this);
    }

    public void ChangeColor()
    {
        changeBlockColor.Execute(cursor.cursorColor);
        gameManager.commandHistory.Push(changeBlockColor);
    }
}
