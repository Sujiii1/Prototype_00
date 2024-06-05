using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private IObjectPool<ObjectSpawner> obstaclePool;
    private Vector3 direction;

    public void SetManagePool(IObjectPool<ObjectSpawner> pool)
    {
        obstaclePool = pool;
    }
    public void Shoot(Vector3 dir)
    {
        direction = dir.normalized;
       // Invoke("")
    }
    public void DestroyObstacle()
    {
        obstaclePool.Release(this);
    }


}
