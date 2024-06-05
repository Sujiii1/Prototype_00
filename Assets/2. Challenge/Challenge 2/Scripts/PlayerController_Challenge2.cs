using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Challenge2 : MonoBehaviour
{
    public GameObject dogPrefab;
    private float creatDogTime = 3f;
   // private bool isCreating = false;
    private bool hasCreated = false;
    

    private void OnCreateDog(InputValue value)
    {
        if (value.isPressed && !hasCreated)
        {
            hasCreated = true;
           // isCreating = true;
            StartCoroutine(CreateDogDelay_Co());
        }
    }

    private IEnumerator CreateDogDelay_Co()
    {
        //2초 뒤인가?
       // isCreating = false;
        yield return new WaitForSeconds(creatDogTime);
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        hasCreated = false;
    }



    /*    private void Update()
        {
            OmCreateDog();
        }

        private void OmCreateDog()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isCreating)
            {
                isCreating = true;
                StartCoroutine(CreateDogDelay_Co());
            }
        }

        private IEnumerator CreateDogDelay_Co()
        {s
            isCreating = false;
            yield return new WaitForSeconds(creatDogTime);
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    */
}
