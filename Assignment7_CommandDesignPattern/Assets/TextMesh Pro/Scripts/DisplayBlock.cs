using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Anna Breuker
 * DisplayBlock.cs
 * Assignment 7 - Command Pattern
 * Code for the fixed blocks that randomizes their color and checks if
 * the player's blocks match.
 */
public class DisplayBlock : MonoBehaviour
{
    public Image blockImage;
    public PatternBlock matchingBlock;
    public GameManager gameManager;

    public bool isCorrect;
    public bool isNotCorrect;

    Color[] colors = { new Color(255, 0, 0), new Color(0, 255, 0), new Color(0, 0, 255) };
    // Start is called before the first frame update
    void Start()
    {
        blockImage = GetComponent<Image>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        isCorrect = false;
        isNotCorrect = true;

        int randomIndex = Random.Range(0, 3);
        blockImage.color = colors[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (matchingBlock.blockImage.color == blockImage.color && isNotCorrect)
        {
            gameManager.correctTiles++;
            isCorrect = true;
            isNotCorrect = false;
        }
        else if (isCorrect && matchingBlock.blockImage.color != blockImage.color)
        {
            gameManager.correctTiles--;
            isCorrect = false;
            isNotCorrect = true;
        }
    }
}
