using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject EnemyGameObject;
    public GameObject[] enemies;
    public GameObject AttackPrefab;
    public int Health = 100;
    public int Darkness = 0;
    private const float CriticalArea = .15f;
    private UI_Manager uimanager;
    public bool aDam = false;

    public GameObject bulletPrefab;
    private float speed = 20.0f;

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
        Shoot();
    }

    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + .203f);
            Vector2 direction = target - myPos;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bulletPrefab, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
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

    public void Damage()
    {
        Health--;
    }

    public void Battery()
    {
        Health += 20;

        if (Health > 100)
        {
            Health = 100;
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
