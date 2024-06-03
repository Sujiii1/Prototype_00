using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //Create
    [SerializeField] private GameObject[] animalPrefebs;
    private float spawnRangeX = 20;
    private float createPos = 15;


    /*private void Start()
    {
        InvokeRepeating("Create", 2, 1.5f);
    }*/

/*    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Create();
        }
    }*/

    #region [InputSystem _ CreateAnimal]
    private void OnCreateAnimal(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("OnCreateAnimal");

            Create();
        }
    }

    public void Create()
    {
        int animalIndex = Random.Range(0, animalPrefebs.Length); ;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, createPos);

        Instantiate(animalPrefebs[animalIndex], spawnPos, animalPrefebs[animalIndex].transform.rotation);
    }
    #endregion
}
