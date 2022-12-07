using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    public int wawenumber = 1;
    void Start()
    {
        SpawnEnemyWawe(1);
    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            wawenumber++;
            SpawnEnemyWawe(wawenumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);


        }
    }
    void SpawnEnemyWawe(int enemiesTpWpawn)
    {
        for (int i = 0; i < enemiesTpWpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnposx = Random.Range(-spawnRange, spawnRange);
        float spawnposz = Random.Range(-spawnRange, spawnRange);


        Vector3 randomposition = new Vector3(spawnposx, 0, spawnposz);
        return randomposition;
    }
}
