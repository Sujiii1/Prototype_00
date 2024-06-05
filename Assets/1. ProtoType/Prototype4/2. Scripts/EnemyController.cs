using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour    //Enemy Move
{
    [SerializeField] private float enemySpeed = 2f;
    private GameObject player;
    private Rigidbody enemyRB;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;    //Code ´Ü¼øÈ­
        enemyRB.AddForce(lookDirection * enemySpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
