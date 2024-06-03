using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX_Challenge3 : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX_Challenge3 playerControllerScript;


    private void Awake()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX_Challenge3>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        
    }

    // Spawn obstacles
    private void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(Random.Range(5, 15), 8, 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}
