using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Challenge2 : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private int ballPrefabsIndex;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 3;
    private float spawnInterval = 5;


    void Start()
    {
        //공 생성 사이 시간 랜덤
        float spawnDelay = Random.Range(startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomBall", spawnDelay, spawnDelay);
        //Debug.Log($"spawnDelay : {spawnDelay}");
    }


    void SpawnRandomBall ()
    {
        //ballPrefabsIndex를 Random으로
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        SpawnRandomBall_();
    }

    private void SpawnRandomBall_()
    {
        //다음 공을 생성하기 전에 랜덤 대기 시간 설정
        float nextSpawn = Random.Range(startDelay, spawnInterval);
        Invoke("SpawnRandomBall_", nextSpawn);

        //Debug.Log($"nextSpawn : {nextSpawn}");
    }

}
