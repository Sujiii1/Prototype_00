using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage_Prototype3 : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefeb;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController_Prototype3 player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Prototype3>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    private void SpawnObstacles()
    {
        if(player.isGameOver == false)
        {
            Instantiate(obstaclePrefeb, spawnPos, obstaclePrefeb.transform.rotation);
        }
    }
}
