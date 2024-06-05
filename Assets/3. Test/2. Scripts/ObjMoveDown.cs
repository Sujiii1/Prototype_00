using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveDown : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    private Rigidbody rb;

    private float zLimit = -10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ObjectMove();
    }

    private void ObjectMove()
    {
        rb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zLimit)
        {
            Destroy(gameObject);
        }
    }
}
