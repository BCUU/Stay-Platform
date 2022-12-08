using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    public int wawenumber = 1;
    public int probablity ;
    void Start()
    {
        SpawnEnemyWawe(1);
    }
    private void Update()
    {
        enemyCounter();
    }
    void SpawnEnemyWawe(int enemiesTpWpawn)
    {
        for (int i = 0; i < enemiesTpWpawn; i++)
        {
            probablity = Random.RandomRange(0, 100);
            
            if (probablity<= 25)
            {
                
                Instantiate(enemyPrefab[1], GenerateSpawnPosition(), transform.rotation);
            }
            else if (probablity>35 && probablity<40)
            {
                Instantiate(enemyPrefab[2], GenerateSpawnPosition(), transform.rotation);
            }

            else
            {
                Instantiate(enemyPrefab[0], GenerateSpawnPosition(), transform.rotation);
            }
            
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnposx = Random.Range(-spawnRange, spawnRange);
        float spawnposz = Random.Range(-spawnRange, spawnRange);


        Vector3 randomposition = new Vector3(spawnposx, 0, spawnposz);
        return randomposition;
    }
    void enemyCounter()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            wawenumber++;
            SpawnEnemyWawe(wawenumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
