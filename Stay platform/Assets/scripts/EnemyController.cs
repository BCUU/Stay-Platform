using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody enemyRB;
    private Rigidbody playerRB;
    private GameObject player;
    Vector3 lookDirection;

    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized * speed);
        enemyRB.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    
}
