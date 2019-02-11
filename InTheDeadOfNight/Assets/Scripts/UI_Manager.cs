using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] Darkness;
    public Image DarknessImageDisplay;


    public void UpdateDarkness(int currDarkness)
    {
        DarknessImageDisplay.sprite = Darkness[currDarkness];
    }
}
