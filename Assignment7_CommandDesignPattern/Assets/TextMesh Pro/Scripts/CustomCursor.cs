using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public Transform cursorPos;
    public Color cursorColor;
    public Vector3 cursorDisplacement;

    public Image cursorImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible= false;
        cursorImage = GetComponent<Image>();
        cursorColor = new Color(255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos.position = Input.mousePosition + cursorDisplacement;
        cursorImage.color = cursorColor;
    }
}
