using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Prototype3 : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private ParticleSystem exploparticle;
    [SerializeField] private ParticleSystem dirtparticle;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private float gravityModifire;

    [SerializeField] private bool isGround = true;
    public bool isGameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifire;     //Physics : 모든 물리 가져옴
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGround && !isGameOver)
        {
            isGround = false;
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtparticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            isGameOver = true;
            exploparticle.Play();
            dirtparticle.Stop();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
