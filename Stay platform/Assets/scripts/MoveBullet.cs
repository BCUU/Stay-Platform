using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public GameObject enemy;
    public float bulletMaxRange = 18.0f;
    public float velocitySpeed = 64.0f;
    private bool enemyExisted = false;

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            GetComponent<Rigidbody>().velocity = (enemy.transform.position - transform.position).normalized * velocitySpeed;
            enemyExisted = true;
        }
        if ((transform.position.x > bulletMaxRange || transform.position.y > bulletMaxRange) ||
            (enemyExisted && enemy == null))
        {
            Destroy(gameObject);
        }
    }
}




