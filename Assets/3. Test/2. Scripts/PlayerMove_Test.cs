using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove_Test : MonoBehaviour
{
    public float speed;
    private float horizonInput;
    private float verticalInput;
    private float smooth = 30f;

    private float zBound = 8f;

    private Rigidbody playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        PlayerBoundary();
    }

    public void PlayerMove(InputAction.CallbackContext context)    
    {
        Vector3 input = context.ReadValue<Vector3>();

/*        horizonInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.right * speed * horizonInput);
        playerRB.AddForce(Vector3.forward * speed * verticalInput);
*/

        //Input System 적용, smoothneess 적용
        horizonInput = input.x * speed;
        verticalInput = input.y * speed;

        //playerRB.velocity = new Vector3(horizonInput * speed , 0, verticalInput * speed );
        horizonInput = Mathf.Lerp(playerRB.velocity.x, horizonInput, Time.deltaTime * smooth);
        verticalInput = Mathf.Lerp(playerRB.velocity.z, verticalInput, Time.deltaTime * smooth);

        playerRB.velocity = new Vector3(horizonInput, 0, verticalInput);
    }

    private void PlayerBoundary()
    {
        //경계 체크
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("col Enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
