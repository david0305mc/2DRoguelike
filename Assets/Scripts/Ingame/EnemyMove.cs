using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform targetDestination;
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D rigidbody2d;


    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidbody2d.velocity = direction * speed;
    }
}
