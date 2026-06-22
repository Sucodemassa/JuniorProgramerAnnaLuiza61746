using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 300.0f;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        
        playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Enemy Goal" || collision.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}


