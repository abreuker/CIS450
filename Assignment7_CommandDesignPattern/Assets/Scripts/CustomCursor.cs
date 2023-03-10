using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Transform cursorPos;
    public Vector3 cursorDisplacement;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible= false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos.position = Input.mousePosition + cursorDisplacement;
    }
}
