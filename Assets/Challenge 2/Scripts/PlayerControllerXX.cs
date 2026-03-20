using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerXX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float cooldownTime = 2.0f;
    private float nextSpawnTime = 0;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawnTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);


            nextSpawnTime = Time.time + cooldownTime;  
        }
    }
}
