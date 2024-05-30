using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //Create
    [SerializeField] private GameObject[] animalPrefebs;
    [SerializeField] private int animalIndex;



    #region [InputSystem _ CreateAnimal]
    public void OnCreateAnimal(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
             Debug.Log("Debug");
            Instantiate(animalPrefebs[animalIndex], new Vector3(0, 0, 15), animalPrefebs[animalIndex].transform.rotation);

        }

    }
    #endregion
}
