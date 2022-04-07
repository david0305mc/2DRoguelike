using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    private Vector2 movementVector;
    public float maxSpeed = 10f;
    public float rotationSpeed = 100f;

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        var move = (Vector2)movementVector * maxSpeed * Time.fixedDeltaTime;
        rb2d.velocity = move;
        gameObject.transform.up = move;
        //rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
