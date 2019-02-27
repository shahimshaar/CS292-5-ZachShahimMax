using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float CriticalArea = .15f;
    private GameObject playerObject;
    public GameObject BatteryPrefab;
    private UI_Manager uimanager;
    private SpriteRenderer spriteRenderer;
    public bool isDam = false;
    float DamageRate = 1.0f;


    void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerObject.GetComponent<Player>().Damage();
    }


    void Start()
    {
        uimanager = GameObject.Find("Darkness_PowerUp").GetComponent<UI_Manager>();
    }

    void Update()
    {
        Movement();
        PowerUpX();
        Flip();
    }


    private void Movement()
    {
        Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;

        //Makes enemy move towards the center.
        if (distanceToPlayer.sqrMagnitude >= CriticalArea)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), .5f * Time.deltaTime);
        }

        //Stops enemy when in the critical area.
        if (distanceToPlayer.sqrMagnitude <= CriticalArea)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), 0 * Time.deltaTime);
        }
    }


    // If the enemies back is facing the player, flip the enemy.
    void Flip()
    {
        if (transform.position.x <= 0)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemies enter the critical area they do damage to the player.
        if (other.tag == "Player")
        {
            isDam = true;
            StartCoroutine(Damage());
        }

        // If the enemies are hit by bulby's attacks, they are destroyed.
        if (other.tag == "Projectile")
        {
            int SpawnBat = Random.Range(1, 100);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

            if (SpawnBat == 25)
            {
                Instantiate(BatteryPrefab, myPos, Quaternion.identity);
            }

            playerObject.GetComponent<Player>().EnDeath();
            playerObject.GetComponent<Player>().PowerUp();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    // Makes enemies damage player overtime while they are in the critical area.
    IEnumerator Damage()
    {
        while (isDam == true)
        {
            playerObject.GetComponent<Player>().Damage();
            yield return new WaitForSeconds(DamageRate);
        }
    }

    //Slows time.
    void PowerUpX()
    {
        if (Input.GetKeyDown("x"))
        {
            Time.timeScale = 0.5f;
        }
    }


    // Pushes enemies that are in the critical area back a set distance.
    public void PowerUp1()
    {
        Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;
        float PushRad = 1.0f;

        if (distanceToPlayer.sqrMagnitude <= CriticalArea)
        {
                if (transform.position.x < 0 && transform.position.y > 0)
                {
                    transform.position = new Vector3(transform.position.x - PushRad, transform.position.y + PushRad, transform.position.z);
                }

                else if (transform.position.x < 0 && transform.position.y < 0)
                {
                    transform.position = new Vector3(transform.position.x - PushRad, transform.position.y - PushRad, transform.position.z);
                }

                else if (transform.position.x > 0 && transform.position.y < 0)
                {
                    transform.position = new Vector3(transform.position.x + PushRad, transform.position.y - PushRad, transform.position.z);
                }

                else
                {
                    transform.position = new Vector3(transform.position.x + PushRad, transform.position.y + PushRad, transform.position.z);
                }

        }
    }


    // Destroys enemies in the critical area.
    public void PowerUp2()
    {
            //Setting up the critical area
            Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;

            //Destroys enemies in critical area
            if (distanceToPlayer.sqrMagnitude <= CriticalArea)
            {
                playerObject.GetComponent<Player>().EnDeath();
                Destroy(this.gameObject);
            }
    }

    // Destroys all enemies on the field.
    public void PowerUp3()
    {
            playerObject.GetComponent<Player>().EnDeath();
            Destroy(this.gameObject);

    }
}
