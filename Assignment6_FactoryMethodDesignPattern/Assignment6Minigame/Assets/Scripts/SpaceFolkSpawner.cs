using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFolkSpawner : MonoBehaviour
{
    public SpaceFolkCreator spaceFolkCreator;

    // Start is called before the first frame update
    void Start()
    {
        spaceFolkCreator = new AllyCreator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
