using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * ChangeCursorColor.cs
 * Assignment 7 - Command Pattern
 * A command that changes the color of the cursor when a button is clicked by the player.
 */
public class ChangeCursorColor : Command
{
    CustomCursor customCursor;
    Stack<Color> colorHistory;

    public ChangeCursorColor(CustomCursor customCursor)
    {
        this.customCursor = customCursor;
        colorHistory = new Stack<Color>();

    }
    public void Execute(Color newColor)
    {
        //Debug.Log("cursor color change executing");
        colorHistory.Push(customCursor.cursorColor);
        //Debug.Log("colorHistory: " + colorHistory);

        customCursor.cursorColor = newColor;
    }

    public void Undo()
    {
        if (colorHistory.Count > 0)
        {
            customCursor.cursorColor = colorHistory.Pop();
        }
    }
}
