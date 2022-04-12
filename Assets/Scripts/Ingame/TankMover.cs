using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private TankMovementData movementData;
    private Vector2 movementVector;
    public float currentSpeed = 0;
    public float currentForewadDirection = 1;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
        {
            if (currentForewadDirection == -1)
                currentSpeed = 0;
            currentForewadDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            if (currentForewadDirection == 1)
                currentSpeed = 0;
            currentForewadDirection = -1;
        }

    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (movementVector.magnitude > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        var move = (Vector2)movementVector * currentSpeed * Time.fixedDeltaTime;
        rb2d.velocity = move;
        gameObject.transform.up = move;
        //rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
