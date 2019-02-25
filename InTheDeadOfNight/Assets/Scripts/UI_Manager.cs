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


    public void UpdateDarkness(int currDarkness)
    {
        Debug.LogError(currDarkness);
        DarknessImageDisplay.sprite = Darkness[currDarkness];
    }

    public void UpdateXP(int currXP)
    {
        PowerImageDisplay.sprite = Power[currXP];
    }

}
