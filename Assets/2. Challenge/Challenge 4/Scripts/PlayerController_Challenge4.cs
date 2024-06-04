using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Challenge4 : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private float speedUp = 50;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    [SerializeField] private ParticleSystem runParticle;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            runParticle.Play();
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speedUp ,ForceMode.Impulse);
        }

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown_Co());
        }
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - gameObject.transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }
    }



    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown_Co()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

}
