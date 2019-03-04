 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private GameObject instantiatedObj;
    private GameObject enemyExplosionOject;
    private const float CriticalArea = .4f;
    private GameObject playerObject;
    public GameObject BatteryPrefab;
    private UI_Manager uimanager;
    private SpriteRenderer spriteRenderer;
    public bool isDam = false;
    float speed;
    float DamageRate = 0.65f;



    void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(.5f, 2.0f);
    }


    void Start()
    {
        uimanager = GameObject.Find("Darkness_PowerUp").GetComponent<UI_Manager>();
    }

    void Update()
    {
        Movement();
        Flip();
    }


    private void Movement()
    {
        Vector3 distanceToPlayer = /*playerObject.transform.position*/ new Vector3(0, 0, 0) - this.transform.position;


        //Makes enemy move towards the center.
        if (distanceToPlayer.sqrMagnitude >= CriticalArea)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), speed * Time.deltaTime);
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
            int SpawnBat = Random.Range(1, 50);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

            if (SpawnBat == 25)
            {
                Instantiate(BatteryPrefab, myPos, Quaternion.identity);
            }

            playerObject.GetComponent<Player>().EnDeath(1);
            Destroy(other.gameObject);
            if (transform.position.x <= 0){
                instantiatedObj = (GameObject) Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
                Vector3 newScale = instantiatedObj.transform.localScale;
                newScale.x *= -1;
                instantiatedObj.transform.localScale = newScale;
            }
            else
            {
                instantiatedObj = (GameObject) Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
            Destroy(instantiatedObj, 1.35f);
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

    public void SpawnBat()
    {
        int SpawnBat = Random.Range(1, 50);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        if (SpawnBat == 25)
        {
            Instantiate(BatteryPrefab, myPos, Quaternion.identity);
        }
    }

    // Destroys enemies in the critical area.
    public void PowerUp2()
    {
        //Setting up the critical area
        Vector3 distanceToPlayer = /*playerObject.transform.position*/ new Vector3(0, 0, 0) - this.transform.position;

        //Destroys enemies in critical area
        if (distanceToPlayer.sqrMagnitude <= CriticalArea)
            {
                playerObject.GetComponent<Player>().EnDeath(1);
                Destroy(this.gameObject);
            }
    }
}
