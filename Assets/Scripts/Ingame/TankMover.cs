using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    private Vector2 movementVector;
    public float maxSpeed = 10f;
    public float rotationSpeed = 100f;
    public float acceleration = 70;
    public float deacceleration = 50;
    public float currentSpeed = 0;
    public float currentForewadDirection = 1;

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        //if (movementVector.y > 0)
        //{
        //    currentForewadDirection = 1;
        //}
        //else if (movementVector.y < 0)
        //{
        //    currentForewadDirection = 0;
        //}

    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (movementVector.magnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        var move = (Vector2)movementVector * currentSpeed * Time.fixedDeltaTime;
        rb2d.velocity = move;
        gameObject.transform.up = move;
        //rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
