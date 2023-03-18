using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Anna Breuker
 * GameManager.cs
 * Assignment 7 - Command Pattern
 * Code that manages the overall game and some of the button methods.
 */
public class GameManager : MonoBehaviour
{
    public float correctTiles;
    public TextMeshProUGUI scoreText;

    public Stack<Command> commandHistory;

    public GameObject controlsScreen;
    // Start is called before the first frame update
    void Start()
    {
        commandHistory = new Stack<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Correct Tiles: " + correctTiles + "/15";
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (commandHistory.Count > 0)
            {
                Command lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }

        }
    }

    public void UndoButton()
    {
        if (commandHistory.Count > 0)
        {
            Command lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
    }

    public void ResetPuzzle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ShowControls()
    {
        controlsScreen.SetActive(true);   
    }

    public void HideControls()
    {
        controlsScreen.SetActive(false);
    }
}
