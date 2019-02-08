using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private const float CriticalArea = 5F;
    private GameObject playerGameObject;

    void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Movement();
        PowerUp2();

    }

    //Makes enemy move towards the center
    private void Movement()
    {
        Vector3 distanceToPlayer = playerGameObject.transform.position - this.transform.position;

        if (distanceToPlayer.sqrMagnitude >= CriticalArea)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), 3 * Time.deltaTime);
            }

        if (distanceToPlayer.sqrMagnitude <= CriticalArea)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), 0 * Time.deltaTime);
            }       
    }

    void PowerUp2()
    {
        if (Input.GetKeyDown("a"))
        {
            //Setting up the critical area
            Vector3 distanceToPlayer = playerGameObject.transform.position - this.transform.position;

            //Destroys enemies in critical area
            if (distanceToPlayer.sqrMagnitude <= CriticalArea)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
