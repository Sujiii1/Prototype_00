using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController_Prototype4 : MonoBehaviour    //Player Move,Focus/ Item, Enemy 판별 
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject powerUpIndicator;
    private Rigidbody playerRB;
    private GameObject focalPoint;

    public  bool isPowerUp = false;
    private float powerUpStrangth = 10f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }
    private void Update()
    {
        PlayerMove();
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    private void PlayerMove()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRB.AddForce(focalPoint.transform.forward * speed * verticalInput);
        playerRB.AddForce(focalPoint.transform.right * speed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpDuration_Co());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPowerUp) 
        {
            Debug.Log("Colider With : " + collision.gameObject.name + "with powerUp set to : " + isPowerUp);
            
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();             
            Vector3 awayfromEnemy = collision.gameObject.transform.position - transform.position;

            enemyRB.AddForce(awayfromEnemy * powerUpStrangth, ForceMode.Impulse);       //enemy의 Rigidbody에 힘 가하기
        }
    }

    IEnumerator PowerUpDuration_Co()
    {
        yield return new WaitForSeconds(5f);
        isPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
