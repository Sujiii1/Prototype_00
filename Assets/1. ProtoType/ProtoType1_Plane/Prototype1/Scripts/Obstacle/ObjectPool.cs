using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour         // ��ũ��Ʈ �̸� ������ ObjectPool �̾�� ��.
{
    [SerializeField] private GameObject obstaclePrefebs;

    //Spawn Objects
    private float currentZposition = 0f; //������Ʈ�� ���� Z�� ��ġ

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
    private ObjectSpawner CreateObstacle()  //   ObjectSpawner�� �ִ� ������Ʈ ����
    {
        ObjectSpawner obstacle = Instantiate(obstaclePrefebs).GetComponent<ObjectSpawner>();
        obstacle.SetManagePool(pool);
        return obstacle;
    }

    private void OnGetObstacle(ObjectSpawner obstacle)  //������Ʈ ���� ��ġ ���� ->��ֹ��� ������ �� ȣ��
    {
        Vector3 spawnPosition = obstacle.gameObject.transform.position + Vector3.forward * currentZposition;
        spawnPosition.y = Random.Range(minY, maxY);
        currentZposition += spawnDistance;

        obstacle.gameObject.SetActive(true);

        //����
        obstacle.transform.position = spawnPosition;
        obstacle.transform.rotation = Quaternion.identity;
    }

    private void OnReleaseObstacle(ObjectSpawner obstacle)  //��ֹ��� Pool�� ��ȯ�� �� ȣ��
    {
        obstacle.gameObject.SetActive(false);
    }
    private void OnDestroyObstacle(ObjectSpawner obstacle)  
    {
        Destroy(obstacle.gameObject);
    }


}
