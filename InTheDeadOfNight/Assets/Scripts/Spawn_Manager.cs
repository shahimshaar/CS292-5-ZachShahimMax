using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private GameObject BigEnemyPrefab;

    private GameObject playerObject;

    IEnumerator beef;
    IEnumerator ESR;

    void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        ESR = EnemySpawnRoutine(0.7f);
        StartCoroutine(ESR);
        beef = BeefBoi();
    }

    public IEnumerator BeefBoi()
    {
        while (true)
        {
            //Spawns enemies along the edge
            int SpawnPos = Random.Range(1, 3);
            float randomy = Random.Range(0, 1.0f);
            float randomx = Random.Range(0, 1.0f);
            float SpawnTime = 5.0f;


            //Left side
            if (SpawnPos == 1)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, randomy, 0.0f));
                Instantiate(BigEnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

            //Right side
            else if (SpawnPos == 2)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, randomy, 0.0f));
                Instantiate(BigEnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

        }

    }

    public void Beef(int currDarkness, float currWave)
    {
        if (currDarkness >= 50)
        {
            Player player = playerObject.GetComponent<Player>();
            StartCoroutine(beef);
        }

        if (currDarkness < 50)
        {
            Player player = playerObject.GetComponent<Player>();
            player.currSpawn = true;
            StopCoroutine(beef);
        }

    }


    IEnumerator EnemySpawnRoutine(float SpawnTime)
    {

        while (true)
        {

            //Spawns enemies along the edge
            int SpawnPos = Random.Range(1, 5);
            float randomy = Random.Range(0, 1.0f);
            float randomx = Random.Range(0, 1.0f);
            //float SpawnTime = 0.7f;


            //Left side
            if (SpawnPos == 1)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, randomy, 0.0f));
                Instantiate(EnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

            //Right side
            else if (SpawnPos == 2)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, randomy, 0.0f));
                Instantiate(EnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

            //Top
            else if (SpawnPos == 3)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(randomx, 1.2f, 0.0f));
                Instantiate(EnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

            //Bottom
            else if (SpawnPos == 4)
            {
                Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(randomx, -0.2f, 0.0f));
                Instantiate(EnemyPrefab, v3Pos, Quaternion.identity);
                yield return new WaitForSeconds(SpawnTime);
            }

        }
    }

}