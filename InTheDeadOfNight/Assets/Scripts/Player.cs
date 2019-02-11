using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject EnemyGameObject;
    public int Health = 100;
    public int Darkness = 0;
    public GameObject[] enemies;
    private UI_Manager uimanager;


    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if (uimanager != null)
        {
            uimanager.UpdateDarkness(Darkness);
        }
    }


    void Update()
    {
        Death();
        DarknessMeter();
    }

    void DarknessMeter()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");      //stores each enemy on screen into a list
        Darkness = enemies.Length * 5;                                            //updates darkness
        uimanager.UpdateDarkness(Darkness/5);                                 //Passes darkness into the uimanger to update                                 
    }


    void Death()
    {

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Darkness == 100)
        {
            Destroy(this.gameObject);
        }
    }
}
