using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 10.0f;
    private PlayerControllerZ playerControllerScript;
    private float leftBound = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerZ>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}