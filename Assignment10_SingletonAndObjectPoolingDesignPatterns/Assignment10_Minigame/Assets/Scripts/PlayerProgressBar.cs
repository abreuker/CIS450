using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerProgressBar : MonoBehaviour
{
    public Image frogImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gamePaused)
        {
            frogImage.GetComponent<RectTransform>().anchoredPosition += new Vector2( Time.deltaTime * GameManager.instance.playerSpeed, 0);
        }
    }
}
