using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerW : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    void Update()
    {

        enemyCount = FindObjectsByType<EnemyX>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
            waveCount++;
        }
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -5);

        if (FindObjectsByType<PlayerControllerW>(FindObjectsSortMode.None).Length > 0 && FindObjectsByType<EnemyX>(FindObjectsSortMode.None).Length == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }


        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);


            EnemyX enemyScript = spawnedEnemy.GetComponent<EnemyX>();
            if (enemyScript != null)
            {
                enemyScript.speed += (waveCount * 25.0f);
            }
        }

        ResetPlayerPosition();


        Vector3 GenerateSpawnPosition()
        {
            float xPos = Random.Range(-spawnRangeX, spawnRangeX);
            float zPos = Random.Range(spawnZMin, spawnZMax);
            return new Vector3(xPos, 0, zPos);
        }

        void ResetPlayerPosition()
        {
            player.transform.position = new Vector3(0, 1, -7);
            player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}