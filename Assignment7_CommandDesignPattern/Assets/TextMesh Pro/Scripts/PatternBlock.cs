using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        changeBlockColor.Execute(cursor.cursorColor);
        gameManager.commandHistory.Push(changeBlockColor);
    }
}
