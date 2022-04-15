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
        if (targetDestination == null)
            return;
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidbody2d.velocity = direction * speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (targetDestination == null)
            return;

        if (collision.gameObject == targetDestination.gameObject)
        {
            collision.gameObject.GetComponent<Damagable>().Hit(5);
        }
    }
}
