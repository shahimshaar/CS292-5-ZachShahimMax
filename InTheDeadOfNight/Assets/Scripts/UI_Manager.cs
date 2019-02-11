using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] Darkness;
    public Sprite[] Light;
    public Image DarknessImageDisplay;
    public Image LightImageDisplay;


    public void UpdateDarkness(int currDarkness)
    {
        DarknessImageDisplay.sprite = Darkness[currDarkness];
    }

    public void UpdateLight(int currLight)
    {
        LightImageDisplay.sprite = Light[currLight];
    }

}
