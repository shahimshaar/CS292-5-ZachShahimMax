using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp3_Button : MonoBehaviour
{
    public GameObject playerObject;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePowerUp3);
    }


    private void TogglePowerUp3()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerObject.GetComponent<Player>().PowerUp3();
        Debug.Log("Button was pressed, powerupScript");
    }
}