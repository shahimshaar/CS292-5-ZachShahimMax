using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float CriticalArea = .15f;
    private GameObject playerObject;
    private Player player;
    private UI_Manager uimanager;

    void Awake()
    {
        player = GetComponent<Player>();
        playerObject = GameObject.FindWithTag("Player");
    }


    void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    void Update()
    {
        Movement();
        PowerUp2();
        PowerUp3();

    }


    private void Movement()
    {
        Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;

        //Makes enemy move towards the center
        if (distanceToPlayer.sqrMagnitude >= CriticalArea)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), .5f * Time.deltaTime);
        }

        //Stops enemy when in the critical area
        if (distanceToPlayer.sqrMagnitude <= CriticalArea)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), 0 * Time.deltaTime);
        }
    }


    void PowerUp2()
    {
        if (Input.GetKeyDown("s"))
        {
            //Setting up the critical area
            Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;

            //Destroys enemies in critical area
            if (distanceToPlayer.sqrMagnitude <= CriticalArea)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void PowerUp3()
    {
        if (Input.GetKeyDown("d"))
        {
            //Setting up the critical area
            Vector3 distanceToPlayer = playerObject.transform.position - this.transform.position;

            //Destroys enemies in critical area
            if (distanceToPlayer.sqrMagnitude <= CriticalArea || distanceToPlayer.sqrMagnitude >= CriticalArea)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
