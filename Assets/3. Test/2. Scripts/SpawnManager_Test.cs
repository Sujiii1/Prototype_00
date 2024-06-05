using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Test : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemysPrefebs;
    [SerializeField] private GameObject powerUpPrefebs;

    private float zSpawnpos = 8f;
    private float xSpawnRange = 10f;
    private float ySpawn = 0.75f;

    private float zPowerUpRange = 5.0f;

    private void Start()
    {
        SpawnEnemy();
        SpawnpowerUp();
    }

    private void SpawnEnemy()
    {
        float xRandom = Random.Range(xSpawnRange, -xSpawnRange);
        int randonIndex = Random.Range(0, EnemysPrefebs.Length);

        Vector3 spawnPos = new Vector3(xRandom, ySpawn, zSpawnpos);

        Instantiate(EnemysPrefebs[randonIndex], spawnPos, EnemysPrefebs[randonIndex].gameObject.transform.rotation);
    }

    private void SpawnpowerUp()
    {
        float xRandom = Random.Range(xSpawnRange, -xSpawnRange);
        float zRandom = Random.Range(zPowerUpRange, -zPowerUpRange);

        Vector3 spawnPos = new Vector3(xRandom, ySpawn, zRandom);

        Instantiate(powerUpPrefebs, spawnPos, powerUpPrefebs.gameObject.transform.rotation);
    }
}
