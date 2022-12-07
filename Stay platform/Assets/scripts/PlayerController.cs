using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;

    private Rigidbody playerRb;

    public bool hasPowerUp = false;

    private float powerupstrength = 15f;
    public GameObject selectionRings;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }


    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        selectionRings.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            selectionRings.SetActive(true);
            StartCoroutine(PowerupCcountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRigidb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidb.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCcountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        selectionRings.SetActive(false);

    }
}
