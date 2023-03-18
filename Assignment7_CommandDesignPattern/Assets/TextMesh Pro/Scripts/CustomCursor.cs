using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * CustomCursor.cs
 * Assignment 7 - Command Pattern
 * Code that both manages the custom cursor and the actions the 
 * player can take by clicking things.
 */
public class CustomCursor : MonoBehaviour
{
    public GameManager gameManager;

    public Transform cursorPos;
    public Color cursorColor;
    public Vector3 cursorDisplacement;

    private Command changeCursorColor;

    public ColorButton colorButton;

    public Image cursorImage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Cursor.visible= false;
        cursorImage = GetComponent<Image>();
        cursorColor = new Color(255,255,255);

        changeCursorColor = new ChangeCursorColor(this);

        colorButton = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ColorButton>();
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos.position = Input.mousePosition + cursorDisplacement;
        cursorImage.color = cursorColor;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeCursorColor.Execute(new Color(255, 0, 0));
            gameManager.commandHistory.Push(changeCursorColor);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeCursorColor.Execute(new Color(0, 0, 255));
            gameManager.commandHistory.Push(changeCursorColor);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeCursorColor.Execute(new Color(0, 255, 0));
            gameManager.commandHistory.Push(changeCursorColor);
        }
    }
}
