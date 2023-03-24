using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;

public class GameManager : MonoBehaviour
{

    public float kittiesKlicked;
    public int clickValue;
    public TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        clickValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Pets: " + (int)kittiesKlicked;
    }

    public void ClickerButton()
    { 
        Debug.Log("Button pressed");
        kittiesKlicked += clickValue;
    }
}
