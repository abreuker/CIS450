using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public CustomCursor customCursor;

    private void Start()
    {
        customCursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
    }
    public void ChangeColor(string colorType)
    {
        Debug.Log("button pressed");
        if (colorType.Equals("RED"))
        {
            customCursor.cursorColor = new Color(255, 0, 0);
        }
        else if (colorType.Equals("BLUE"))
        {
            customCursor.cursorColor = new Color(0, 0, 255);
        }
        else 
        {
            customCursor.cursorColor = new Color(0, 255, 0);
        }
    }
}
