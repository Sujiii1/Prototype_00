using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;

    //Speed
    [SerializeField]private float speed;
    [SerializeField]private float acceleratSpeed;
    [SerializeField]private float maxAccelateSpeed;
    [SerializeField] private float rotateSpeed;

    //Pool
    [SerializeField] ObjectSpawner objectspawner;
    public  ObjectPool objectPool;
    public float destroyDelay = 2f;

    //GameOver
    [SerializeField] private GameObject EndPopUp;


    private void Update()
    {
        MovePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PassZone"))
        {
            //SpeedUp +10%
            acceleratSpeed *= 1.1f;
            if (acceleratSpeed > maxAccelateSpeed)
            {
                acceleratSpeed = maxAccelateSpeed;
            }

            //Pooling에서 Dequeue/Destroy 하는 역할
            ObjectSpawner objectSpawner = objectPool.poolQueue.Dequeue();
            objectSpawner.Invoke("DestroyObstacle", destroyDelay);
            objectPool.poolQueue.Enqueue(objectPool.pool.Get());     //다음 오브젝트 생성

            //ScoreUp
            ScoreManager.instance.UpScore();
        }
        else if(other.CompareTag("Obstacles"))
        {
            acceleratSpeed = 1f;    //Basic Speed

            // + End
            EndGame();        
        }
    }

    private void MovePlayer()
    {
        verticalInput = Input.GetAxis("Vertical");

        //I,O Key
        if (Input.GetKey(KeyCode.I))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.I))
        {
            verticalInput = -1;
        }

        transform.Translate(Vector3.forward * speed  * acceleratSpeed * Time.deltaTime );
        transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime * verticalInput);
    }

    public void EndGame()
    {
        EndPopUp.gameObject.SetActive(true);
        ScoreManager.instance.SavePreScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EndPopUp.gameObject.SetActive(false);

        ScoreManager.instance. score = 0;
        ScoreManager.instance. UpdateScore();
    }
}
