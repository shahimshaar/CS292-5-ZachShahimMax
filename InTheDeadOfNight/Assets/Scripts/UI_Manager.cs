using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] Darkness;
    public Sprite[] Power;
    public Image DarknessImageDisplay;
    public Image PowerImageDisplay;
    public Text scoreText;
    public int score;


    public void UpdateDarkness(int currDarkness)
    {
        DarknessImageDisplay.sprite = Darkness[currDarkness];
    }

    public void UpdateXP(int currXP)
    {
        PowerImageDisplay.sprite = Power[currXP];
    }

    public void UpdateScore()
    {
        score += 25;
        scoreText.text = "Score: " + score.ToString("0");

    }

}
