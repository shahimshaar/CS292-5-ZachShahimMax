using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {

            //Spawns enemies along the edge
            int SpawnPos = Random.Range(1, 4);

                //Left side
                if (SpawnPos == 1)
                {
                    float randomy = Random.Range(-5.0f, 5.0f);
                    Instantiate(EnemyPrefab, new Vector3(-15.5f, randomy, 0), Quaternion.identity);
                    yield return new WaitForSeconds(2.0f);
                }

                //Right side
                else if (SpawnPos == 2)
                {
                    float randomy = Random.Range(-5.0f, 5.0f);
                    Instantiate(EnemyPrefab, new Vector3(15.5f, randomy, 0), Quaternion.identity);
                    yield return new WaitForSeconds(2.0f);
                }

                //Top
                else if (SpawnPos == 3)
                {
                    float randomx = Random.Range(-15.5f, 15.5f);
                    Instantiate(EnemyPrefab, new Vector3(randomx, 5.0f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(2.0f);
                }

                //Bottom
                else if (SpawnPos == 4)
                {
                    float randomx = Random.Range(-15.5f, 15.5f);
                    Instantiate(EnemyPrefab, new Vector3(randomx, -5.5f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(2.0f);
                }
        }
    }

}