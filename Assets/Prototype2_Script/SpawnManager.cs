using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefebs;
    [SerializeField] private int animalIndex;



    public void OnCreateAnimal(InputAction.CallbackContext context)
    {
        if(context.action.triggered)
        {
            Debug.Log(context);
           Instantiate(animalPrefebs[animalIndex], new Vector3(0, 0, 20), animalPrefebs[animalIndex].transform.rotation);
        }
    }
}
