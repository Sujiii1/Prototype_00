using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 19f;
    //[SerializeField] private float lowBound = -25f;

    private void Update()
    {
        BoundaryReMove();
    }

    private void BoundaryReMove()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
       /* else if(transform.position .z < lowBound)
        {
            Destroy(gameObject);
        }*/

    }    
}
