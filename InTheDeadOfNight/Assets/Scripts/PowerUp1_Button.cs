using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp1_Button : MonoBehaviour
{
    public GameObject playerObject;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePowerUp1);
    }


    private void TogglePowerUp1()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerObject.GetComponent<Player>().PowerUp1();
        Debug.Log("Button was pressed, powerupScript");
    }
}