using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody enemyRb;
    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized * speed);
        enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
