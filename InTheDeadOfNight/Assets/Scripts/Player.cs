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

    }

    // Update is called once per frame
    void Update()
    {
        Death();
        DarknessMeter();
    }

    void DarknessMeter()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Darkness = enemies.Length;
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
