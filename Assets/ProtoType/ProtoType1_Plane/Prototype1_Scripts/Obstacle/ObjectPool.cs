using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour         // 스크립트 이름 무조건 ObjectPool 이어야 함.
{
    [SerializeField] private GameObject obstaclePrefebs;

    //Spawn Objects
    private float currentZposition = 0f; //오브젝트의 현재 Z축 위치

    [SerializeField] private float spawnDistance = 80f;

    //Random Y
    [SerializeField] private float minY = -10f;
    [SerializeField] private float maxY = -50f;
    

    //Pool
    public IObjectPool<ObjectSpawner> pool;
    public Queue<ObjectSpawner> poolQueue;


    private void Awake()
    {
        pool = new ObjectPool<ObjectSpawner>(CreateObstacle, OnGetObstacle, OnReleaseObstacle, OnDestroyObstacle, maxSize: 10);
    }

    private void Start()
    { 
        poolQueue = new Queue<ObjectSpawner>();

        for(int i = 0; i<9; i++)
        {
            poolQueue.Enqueue(pool.Get());
        }
    }

    //Pooling
    private ObjectSpawner CreateObstacle()  //   ObjectSpawner에 있는 오브젝트 생성
    {
        ObjectSpawner obstacle = Instantiate(obstaclePrefebs).GetComponent<ObjectSpawner>();
        obstacle.SetManagePool(pool);
        return obstacle;
    }

    private void OnGetObstacle(ObjectSpawner obstacle)  //오브젝트 생성 위치 결정 ->장애물을 생성할 때 호출
    {
        Vector3 spawnPosition = obstacle.gameObject.transform.position + Vector3.forward * currentZposition;
        spawnPosition.y = Random.Range(minY, maxY);
        currentZposition += spawnDistance;

        obstacle.gameObject.SetActive(true);

        //연결
        obstacle.transform.position = spawnPosition;
        obstacle.transform.rotation = Quaternion.identity;
    }

    private void OnReleaseObstacle(ObjectSpawner obstacle)  //장애물을 Pool에 반환할 때 호출
    {
        obstacle.gameObject.SetActive(false);
    }
    private void OnDestroyObstacle(ObjectSpawner obstacle)  
    {
        Destroy(obstacle.gameObject);
    }


}
