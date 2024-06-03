using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController_Prototype2 : MonoBehaviour
{
    //Player Move
    private float horizontalInput;
    private float rangeX = 15.3f; 
    [SerializeField]private float speed;

    //Shoot
    [SerializeField] GameObject itemPrefebs;

    public SpawnManager spawnManager;

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {

        if(transform.position.x < -rangeX)
        {
            transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
        }
        if ( transform.position.x > rangeX)
        {
            transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }


    #region [InputSystem _ Shoot]

    public void OnShoot(InputValue value)      //Event 호출
    {
        if(value.isPressed)
        {
            Debug.Log("OnShoot");
            Instantiate(itemPrefebs, transform.position, itemPrefebs.transform.rotation);   //Shoot
        }
    }

    public void OnCreateAnimal(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("OnCreateAnimal");
            spawnManager.Create();
        }
    }


    #endregion
    /*    #region [InputSystem _ Shoot]

        public void OnShoot(InputAction.CallbackContext context)      //Event 호출
        {
            if (isCanShoot)      //key가 두 번 호출X
            {
                Vector3 input = context.ReadValue<Vector3>();

                Instantiate(itemPrefebs, transform.position, itemPrefebs.transform.rotation);   //Shoot
                isCanShoot = false;
                Invoke("ResetShoot", shootDelay);
            }
        }

        private void ResetShoot()
        {
            isCanShoot = true;
        }
        #endregion*/

}
