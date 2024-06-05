using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController_Prototype3 player;
    private float leftBound = -10f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Prototype3>();
    }

    private void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (player.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))      //������Ʈ�� "Obstacles" ��� Ư�� ��ġ���� ����
        {
            Destroy(gameObject);
        }
    }
}
