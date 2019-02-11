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
            int SpawnPos = Random.Range(1, 5);
            float SpawnTime = .5f;

                //Left side
                if (SpawnPos == 1)
                {
                    float randomy = Random.Range(-1.7f, 1.7f);
                    Instantiate(EnemyPrefab, new Vector3(-3.0f, randomy, 0), Quaternion.identity);
                    yield return new WaitForSeconds(SpawnTime);
                }

                //Right side
                else if (SpawnPos == 2)
                {
                    float randomy = Random.Range(-1.7f, 1.7f);
                    Instantiate(EnemyPrefab, new Vector3(3.0f, randomy, 0), Quaternion.identity);
                    yield return new WaitForSeconds(SpawnTime);
                }

                //Top
                else if (SpawnPos == 3)
                {
                    float randomx = Random.Range(-3.0f, 3.0f);
                    Instantiate(EnemyPrefab, new Vector3(randomx, 1.7f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(SpawnTime);
                }

                //Bottom
                else if (SpawnPos == 4)
                {
                    float randomx = Random.Range(-2.8f, 2.8f);
                    Instantiate(EnemyPrefab, new Vector3(randomx, -1.7f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(SpawnTime);
                }
        }
    }

}