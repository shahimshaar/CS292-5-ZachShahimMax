using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] Darkness;
    public Image DarknessImageDisplay;

    void Start()
    {

    }

    public void UpdateLives(int currentlives)
    {
        Debug.Log("Player lives" + currentlives);
        DarknessImageDisplay.sprite = lives[currentlives];
    }


    public void UpdateScore()
    {

    }
}
