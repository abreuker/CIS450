using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ColorButton.cs
 * Assignment 7 - Command Pattern
 * Code for the buttons that the player can click to change the cursor color.
 */
public class ColorButton : MonoBehaviour
{
    public GameManager gameManager;
    public CustomCursor customCursor;
    private Command changeCursorColor;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        customCursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
        changeCursorColor = new ChangeCursorColor(customCursor);
    }
    public void ChangeColor(string colorType)
    {
        Debug.Log("button pressed");
        if (colorType.Equals("RED"))
        {
            changeCursorColor.Execute(new Color(255, 0, 0));
            gameManager.commandHistory.Push(changeCursorColor);
        }
        else if (colorType.Equals("BLUE"))
        {
            changeCursorColor.Execute(new Color(0, 0, 255));
            gameManager.commandHistory.Push(changeCursorColor);
        }
        else 
        {
            changeCursorColor.Execute(new Color(0, 255, 0));
            gameManager.commandHistory.Push(changeCursorColor);
        }
    }
}
