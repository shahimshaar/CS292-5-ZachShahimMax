using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp2_Button : MonoBehaviour
{
    public GameObject playerObject;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePowerUp2);
    }


    private void TogglePowerUp2()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerObject.GetComponent<Player>().PowerUp2();
        Debug.Log("Button was pressed, powerupScript");
    }
}