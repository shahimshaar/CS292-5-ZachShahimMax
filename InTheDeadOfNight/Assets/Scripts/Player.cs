using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int StartHealth = 100;
    public int CurrHealth;
    public int Darkness = 0;

    private void Awake()
    {
        CurrHealth = StartHealth;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Debug.Log("Health: "+ CurrHealth);
        Debug.Log(CurrHealth);
    }

    void Death()
    {

        if (CurrHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
