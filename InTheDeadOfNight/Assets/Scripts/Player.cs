using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] enemyObject;
    public GameObject AttackPrefab;
    private UI_Manager uimanager;
    public int Darkness = 0;
    public int XP = 0;
    private const float CriticalArea = .5f;

    public bool aDam = false;
    private float speed = 10.0f;


    void Awake()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Start()
    {
        // Sets Darkness meters initial state.
        uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if (uimanager != null)
        {
            uimanager.UpdateDarkness(Darkness/5);
            uimanager.UpdateXP(XP/10);
        }
    }


    void Update()
    {
        Shoot();
        //Rotate();
        DarknessMeter();
        PowerMeter();
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        PowerUp1();
        PowerUp2();
        PowerUp3();
        GodMode();
        Death();
        Debug.Log(XP);
    }

    private void Shoot()
    {

        // Shoots a projectile in the direction of the mouse click
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z));
            Vector3 myPos = new Vector3(transform.position.x, transform.position.y + .203f,0);
            Vector3 direction = target - myPos;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(AttackPrefab, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    /*private void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 vectorToTarget = mouse - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2000000);
        }

    }*/


    void DarknessMeter()
    {
        // Updates darkness meter. Since the darkness meter is a sprite with 20 elements, it can only take in elements corrisponding to multiples of 5.
        if (Darkness % 5 == 0)
        {
            uimanager.UpdateDarkness(Darkness / 5);
        }                               
    }

    void PowerMeter()
    {
        if (XP % 10 == 0)
        {
            uimanager.UpdateXP(XP/10);
        }
    }

    // Does damage to the player when called
    public void Damage()
    {
        Darkness++;

        if(Darkness < 0)
        {
            Darkness = 0;
        }
    }


    // Removes darkness when enemy is destroyed.
    public void EnDeath()
    {
        Darkness--;
    }

    // Adds XP
    public void PowerUp()
    {
        XP++;

        if (XP > 100)
        {
            XP = 100;
        }
    }

    public void PowerUp1()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetKeyDown("a"))
        {
            if (XP >= 30)
            {
                for (int i = 0; i < enemyObject.Length; i++)
                {
                    Debug.Log(enemyObject[i]);
                    enemyObject[i].GetComponent<EnemyAI>().PowerUp1();
                }

                XP = XP - 30;
            }
        }
    }

    public void PowerUp2()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKeyDown("s"))
        {
            if (XP >= 60)
            {
                for (int i = 0; i < enemyObject.Length; i++)
                {
                    enemyObject[i].GetComponent<EnemyAI>().PowerUp2();
                }

                XP = XP - 60;
            }
        }
    }

    public void PowerUp3()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKeyDown("d"))
        {
            if (XP == 100)
            {
                for (int i = 0; i < enemyObject.Length; i++)
                {
                    enemyObject[i].GetComponent<EnemyAI>().PowerUp3();
                }

                XP = 0;
            }
        }
    }

    public void GodMode()
    {
        if (Input.GetKeyDown("m"))
        {
            Darkness = 0;
            XP = 100;
        }

    }

    //Battery upgrades XP.
    public void Battery()
    {
        XP = XP + 10;
    }


    // Death condition.
    void Death()
    {
        if (Darkness == 100)
        {
            FindObjectOfType<GameManager>().GameOver();
            Destroy(this.gameObject);
        }

    }
}
