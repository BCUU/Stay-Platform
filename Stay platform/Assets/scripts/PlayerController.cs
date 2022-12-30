using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool hasPowerUp = false;


    public float powerupstrength = 15f;
    public float powerOfFast = 0.5f;
    public float powerOfStrengt = 2f;



    public GameObject selectionRings;
    public GameObject bullet;
    public GameObject[] enemy;
    public GameObject[] st_enemy;
    public GameObject[] fs_enemy;
    int enemyCount;
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
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        st_enemy = GameObject.FindGameObjectsWithTag("StrongEnemy");
        //fs_enemy = GameObject.FindGameObjectsWithTag("FastEnemy");
        
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            
        //    for (int i = 0; i < enemyCount; i++)
        //    {
        //        if (enemy[i] != null)
        //        {
        //            Vector3 awayFromPlayer = enemy[i].transform.position-transform.position;

        //            Vector3 bulletVector = awayFromPlayer.normalized;
        //            Quaternion bulletRotation = Quaternion.LookRotation(bulletVector, Vector3.up);

        //            GameObject bullet = Instantiate(bullet, transform.position + bulletVector * bulletOffsetRadius, bulletRotation);
        //            bullet.GetComponent<MoveBullet>().enemy = enemy[i];


        //            GameObject new_bullet = Instantiate(bullet,transform.position, Quaternion.identity);
        //            new_bullet.GetComponent<Rigidbody>().velocity = (enemy[i].transform.position - transform.position);
        //        }

        //        //    Rigidbody bulletrb = bullet.gameObject.GetComponent<Rigidbody>();
        //        //    Vector3 awayFromPlayer = enemy[i].transform.position;
        //        //    bulletrb.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
        //        //}
        //        //if (st_enemy[i]!=null)
        //        //{
        //        //    Instantiate(bullet, transform.position, transform.rotation);
        //        //    Rigidbody bulletrb = bullet.gameObject.GetComponent<Rigidbody>();
        //        //    Vector3 awayFromPlayer = st_enemy[i].transform.position;
        //        //    bulletrb.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
        //        //}
        //        /*if (fs_enemy[i]!=null)
        //        {
        //            Instantiate(bullet, transform.position, transform.rotation);
        //            Rigidbody bulletrb = bullet.gameObject.GetComponent<Rigidbody>();
        //            Vector3 awayFromPlayer = fs_enemy[i].transform.position;
        //            bulletrb.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
        //        }*/
                
                
        //    }
            
        //}
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
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
        if (collision.gameObject.CompareTag("StrongEnemy"))
        {
            Rigidbody enemyRigidbody =gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (transform.position - collision.gameObject.transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerOfStrengt, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("FastEnemy"))
        {
            Rigidbody enemyRigidbody = gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (transform.position - collision.gameObject.transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerOfFast, ForceMode.Impulse);
        }


    }
    IEnumerator PowerupCcountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        selectionRings.SetActive(false);

    }
}
