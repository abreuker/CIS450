using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternBlock : MonoBehaviour
{
    public CustomCursor cursor;
    public Image blockImage;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
        blockImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        blockImage.color = cursor.cursorColor;
    }
}
