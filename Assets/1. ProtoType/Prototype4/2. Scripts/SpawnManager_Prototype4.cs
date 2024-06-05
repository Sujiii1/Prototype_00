using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SpawnManager_Prototype4 : MonoBehaviour    //Enemy, PowerUp Spawn
{
    [SerializeField] private GameObject spawnEnemy;
    [SerializeField] private GameObject powerUpIndicator;
    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;     //생성 Enemy

    private void Start()
    {
        SpawnEnemy(3);
        Instantiate(powerUpIndicator, GenerateSpawnPos(), powerUpIndicator.transform.rotation);     //초기 PowerUp 아이템 생성
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;   //씬에 있는 Enemy들 찾기

        if (enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemy(waveNumber);     //적을 많이 물리칠 수록 생성 증가

            //PowerUp 아이템 생성
            Instantiate(powerUpIndicator, GenerateSpawnPos(), powerUpIndicator.transform.rotation);     
        }
    }
    private void SpawnEnemy(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(spawnEnemy, GenerateSpawnPos(), spawnEnemy.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()      // void -> Vector3값으로 return
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(randomX, 0, randomZ);

        return randomPos;
    }
}
