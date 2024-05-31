using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_C : MonoBehaviour
{
    public GameObject dogPrefab;
    private float creatDogTime = 3f;
    private bool isCreating = true;



      private void OnCreateDog(InputValue value)
    {
        
            if (value.isPressed)
            {
            if(!isCreating)
            {
                isCreating = true;
                StartCoroutine(CreateDogDelay_Co());
            }
               
            }
        

        
    }
    private IEnumerator CreateDogDelay_Co()
    {
        isCreating = false;
        yield return new WaitForSeconds(creatDogTime);
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);           
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
