using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        Movement();
        DestroyEnemy();
    }

    private void Movement()
    {
        //Makes enemy move towards the center
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0), Random.Range(.5f,3.0f) * Time.deltaTime);
    }

    void DestroyEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
