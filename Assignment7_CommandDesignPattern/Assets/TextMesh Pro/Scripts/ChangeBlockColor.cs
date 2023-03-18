using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ChangeBlockColor.cs
 * Assignment 7 - Command Pattern
 * A command that changes the color of a block clicked on by the player.
 */
public class ChangeBlockColor : Command
{
    PatternBlock patterBlock;
    Stack<Color> colorHistory;

    public ChangeBlockColor(PatternBlock customCursor)
    {
        this.patterBlock = customCursor;
        colorHistory = new Stack<Color>();

    }
    public void Execute(Color newColor)
    {
        //Debug.Log("cursor color change executing");
        colorHistory.Push(patterBlock.blockImage.color);
        //Debug.Log("colorHistory: " + colorHistory);

        patterBlock.blockImage.color = newColor;
    }

    public void Undo()
    {
        if (colorHistory.Count > 0)
        {
            patterBlock.blockImage.color = colorHistory.Pop();
        }
    }
}
