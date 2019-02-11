using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject EnemyGameObject;
    public GameObject[] enemies;
    public int Health = 100;
    public int Darkness = 0;
    private const float CriticalArea = .15f;
    private UI_Manager uimanager;

    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if (uimanager != null)
        {
            uimanager.UpdateDarkness(Darkness);
            uimanager.UpdateLight(Health / 5);
        }
    }


    void Update()
    {
        Death();
        DarknessMeter();
        Lightmeter();
        Debug.Log("Health: " + Health);
    }

    void DarknessMeter()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");      //stores each enemy on screen into a list
        Darkness = enemies.Length * 5;                                            //updates darkness
        uimanager.UpdateDarkness(Darkness / 5);                                 //Passes darkness into the uimanger to update                                 
    }

    void Lightmeter()
    {
        if (Health % 5 == 0)
        {
            uimanager.UpdateLight(Health / 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Health--;
        }

        if (Health % 5 == 0)
        {
            uimanager.UpdateLight(Health / 5);
        }
    }



void Death()
    {
        if (Darkness == 100)
        {
            Destroy(this.gameObject);
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
