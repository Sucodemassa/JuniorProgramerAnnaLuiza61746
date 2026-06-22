using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerZ : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private PlayerControllerZ playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerZ>();

        
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }


    void SpawnObjects()
    {
        
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}