using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] enemyObject;
    [SerializeField]
    public GameObject BigEnemy;
    public GameObject AttackPrefab;
    private GameObject instantiatedObj2;
    public GameObject DeathPrefab;
    public GameObject ShootingAnimation;
    private GameObject instantiatedObj3;
    private UI_Manager uimanager;
    private Spawn_Manager spawnmanager;
    public int Darkness = 0;
    public int XP = 0;
    private const float CriticalArea = .5f;
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    public bool aDam = false;
    public bool currSpawn;
    private float speed = 10.0f;
    public int score = 0;
    float wave;

    void Awake()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        currSpawn = true;
    }

    void Start()
    {
        // Sets Darkness meters initial state.
        uimanager = GameObject.Find("Darkness_PowerUp").GetComponent<UI_Manager>();
        spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        wave = 0;
        SoundManager.PlaySound ("NewGame");

        if (uimanager != null)
        {
            uimanager.UpdateDarkness(Darkness/5);
            uimanager.UpdateXP(XP/10);
        }
    }


    void Update()
    {
        Shoot();
        DarknessMeter();
        PowerMeter();
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        GodMode();
        Death();

        if (Darkness % 5 == 0)
        {
            uimanager.UpdateDarkness(Darkness / 5);
        }

        if (XP % 10 == 0)
        {
            uimanager.UpdateXP(XP / 10);
        }
    }

    private void Shoot()
    {

        // Shoots a projectile in the direction of the mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > canFire)
            {
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 vectorToTarget = mouse - transform.position;
                float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2000000);
                Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                Vector3 myPos = new Vector3(transform.position.x, transform.position.y + .203f, 0);
                instantiatedObj3 = (GameObject)Instantiate(ShootingAnimation, transform.position, transform.rotation);
                Destroy(instantiatedObj3, 0.099f);
                Vector3 direction = target - myPos;
                direction.Normalize();
                GameObject projectile = (GameObject)Instantiate(AttackPrefab, myPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                SoundManager.PlaySound("Attack");

                canFire = Time.time + fireRate;
            }

        }
    }



    void DarknessMeter()
    {
        // Updates darkness meter. Since the darkness meter is a sprite with 20 elements, it can only take in elements corrisponding to multiples of 5.
        if (Darkness % 5 == 0)
        {
            uimanager.UpdateDarkness(Darkness / 5);
        }

        if (Darkness >= 50)
        {
            if (currSpawn == true)
            {
                spawnmanager.Beef(Darkness, wave);
                currSpawn = false;
            }
        }

        else
        {
            spawnmanager.Beef(Darkness, wave);
        }
    }

    void PowerMeter()
    {
        if (XP > 100)
        {
            XP = 100;
        }

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



    public void EnDeath(int EXP)
    {
        score++;
        XP = XP + EXP;

        if (XP > 100)
        {
            XP = 100;
        }
    }

    public void PowerUp1()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        if (XP >= 30)
        {
            Debug.Log("Button was pressed, playerScript");

            Darkness = Darkness - 10;
            XP = XP - 30;
        }
    }

    public void PowerUp2()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        if (XP >= 60)
        {
            for (int i = 0; i < enemyObject.Length; i++)
            {
                enemyObject[i].GetComponent<EnemyAI>().PowerUp2();
            }

            Debug.Log("Button was pressed, playerScript");
            XP = XP - 60;

            Darkness -= 15;
        }
    }

    public void PowerUp3()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        if (XP == 100)
        {
            for (int i = 0; i < enemyObject.Length; i++)
            {
                enemyObject[i].GetComponent<EnemyAI>().SpawnBat();
                Destroy(enemyObject[i]);
                EnDeath(1);
            }

            Debug.Log("Button was pressed, playerScript");
            XP = 0;
            Darkness -= 25;
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

    public void Battery()
    {
        XP = XP + 10;
        Darkness = Darkness - 15;

        SoundManager.PlaySound("Battery");

        if (Darkness < 0)
        {
            Darkness = 0;
        }

        if (XP > 100)
        {
            XP = 100;
        }
    }

    // Death condition and death animation trigger.
    void Death()
    {
        if (Darkness >= 100)
        {
            instantiatedObj2 = (GameObject)Instantiate(DeathPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            SoundManager.PlaySound("Death");
            Destroy(instantiatedObj2.gameObject, 0.5f);
            //Time.timeScale = 0;
        }   
    }
}
