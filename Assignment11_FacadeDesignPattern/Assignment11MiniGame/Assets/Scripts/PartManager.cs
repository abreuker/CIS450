using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * PartManager.cs
 * Assignment 11 - Facade Pattern
 * Code that manages all the parts of your guy.
 */
public class PartManager : MonoBehaviour
{
    public GameObject[] heads;
    public GameObject[] torsos;
    public GameObject[] legs;

    public int headsNum;
    public int torsosNum;
    public int legsNum;

    List<Color> colors;
    List<Color> reverseColors;
    float lerpTime = 4f;
    public SpriteRenderer headRenderer;
    public SpriteRenderer torsoRenderer;
    public SpriteRenderer legsRenderer;
    // Start is called before the first frame update
    void Start()
    {
        colors = new List<Color>() { Color.blue, Color.magenta, Color.red, new Color(1, .502f, 0) , Color.yellow, Color.green, Color.white};
        reverseColors = new List<Color>() { Color.green, Color.yellow, new Color(1, .502f, 0), Color.red, Color.magenta, Color.blue, Color.white };
    }

    public void ChangeHead()
    {
        if (headsNum < heads.Length - 1)
        {
            heads[headsNum].SetActive(false);
            headsNum++;
            heads[headsNum].SetActive(true);
        }
        else
        {
            heads[headsNum].SetActive(false);
            headsNum = 0;
            heads[headsNum].SetActive(true);
        }
    }

    public void ChangeTorso()
    {
        if (torsosNum < torsos.Length - 1)
        {
            torsos[torsosNum].SetActive(false);
            torsosNum++;
            torsos[torsosNum].SetActive(true);
        }
        else
        {
            torsos[torsosNum].SetActive(false);
            torsosNum = 0;
            torsos[torsosNum].SetActive(true);
        }
    }

    public void ChangeLegs()
    {
        if (legsNum < legs.Length - 1)
        {
            legs[legsNum].SetActive(false);
            legsNum++;
            legs[legsNum].SetActive(true);
        }
        else
        {
            legs[legsNum].SetActive(false);
            legsNum = 0;
            legs[legsNum].SetActive(true);
        }
    }

    public void ResetParts()
    {
        //reset heads
        heads[headsNum].SetActive(false);
        headRenderer = heads[headsNum].GetComponent<SpriteRenderer>();
        headRenderer.color = Color.white;
        headsNum = 0;
        heads[headsNum].SetActive(true);

        //reset torsos
        torsos[torsosNum].SetActive(false);
        torsoRenderer = torsos[torsosNum].GetComponent<SpriteRenderer>();
        torsoRenderer.color = Color.white;
        torsosNum = 0;
        torsos[torsosNum].SetActive(true);

        //reset legs
        legs[legsNum].SetActive(false);
        legsRenderer = legs[legsNum].GetComponent<SpriteRenderer>();
        legsRenderer.color = Color.white;
        legsNum = 0;
        legs[legsNum].SetActive(true);
    }

    public IEnumerator ChangeHeadColor()
    {
        headRenderer = heads[headsNum].GetComponent<SpriteRenderer>();
        if (colors.Count >= 2)
        {
            for (int i = 1; i < colors.Count; i++)
            {
                float startTime = Time.time;
                float percentageComplete = 0;

                while (percentageComplete < 1)
                {
                    float elapsedTime = Time.time - startTime;
                    percentageComplete = elapsedTime / (lerpTime / (colors.Count - 1));
                    headRenderer.color = Color.Lerp(colors[i - 1], colors[i], percentageComplete);
                    yield return null;
                }
            }
        }

    }

    public IEnumerator ChangeTorsoColor()
    {
        torsoRenderer = torsos[torsosNum].GetComponent<SpriteRenderer>();
        if (reverseColors.Count >= 2)
        {
            for (int i = 1; i < reverseColors.Count; i++)
            {
                float startTime = Time.time;
                float percentageComplete = 0;

                while (percentageComplete < 1)
                {
                    float elapsedTime = Time.time - startTime;
                    percentageComplete = elapsedTime / (lerpTime / (reverseColors.Count - 1));
                    torsoRenderer.color = Color.Lerp(reverseColors[i - 1], reverseColors[i], percentageComplete);
                    yield return null;
                }
            }
        }

    }

    public IEnumerator ChangeLegsColor()
    {
        legsRenderer = legs[legsNum].GetComponent<SpriteRenderer>();
        if (colors.Count >= 2)
        {
            for (int i = 1; i < colors.Count; i++)
            {
                float startTime = Time.time;
                float percentageComplete = 0;

                while (percentageComplete < 1)
                {
                    float elapsedTime = Time.time - startTime;
                    percentageComplete = elapsedTime / (lerpTime / (colors.Count - 1));
                    legsRenderer.color = Color.Lerp(colors[i - 1], colors[i], percentageComplete);
                    yield return null;
                }
            }
        }

    }
}
