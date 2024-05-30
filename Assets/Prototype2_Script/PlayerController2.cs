using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController2 : MonoBehaviour
{
    //Player Move
    private float horizontalInput;
    private float rangeX = 15.3f; 
    [SerializeField]private float speed;

    //Shoot
    [SerializeField] GameObject itemPrefebs;
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private bool isCanShoot = true;    
        

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


    //InputSystem 
    #region [InputSystem _ Shoot]
    public void OnShoot(InputAction.CallbackContext context)
    {
        if(isCanShoot)      //key�� �� �� ȣ��X
        {
            Vector3 input = context.ReadValue<Vector3>();

            Instantiate(itemPrefebs, transform.position, itemPrefebs.transform.rotation);   //Shoot
            isCanShoot=false;
            Invoke("ResetShoot", shootDelay);
        }
    }

    private void ResetShoot()
    {
        isCanShoot = true;
    }
    #endregion

}
