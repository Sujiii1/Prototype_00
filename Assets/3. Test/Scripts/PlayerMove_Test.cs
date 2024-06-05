using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Test : MonoBehaviour
{
    public float speed;
    private float horizonInput;
    private float verticalInput;

    private float zBound = 8f;

    private Rigidbody playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        horizonInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.right * speed * horizonInput);
        playerRB.AddForce(Vector3.forward * speed * verticalInput);

        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, - zBound);
        }
        else if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}
