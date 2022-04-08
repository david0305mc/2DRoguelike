using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankInput : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Joystick joystick;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();


    // Update is called once per frame
    void Update()
    {

        GetBodyMovemovement();
        //GetTurretMovement();
        //GetShootingInput();
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetBodyMovemovement()
    {
        Vector2 movementVector = new Vector2(joystick.Horizontal + Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") + joystick.Vertical);
        OnMoveBody?.Invoke(movementVector.normalized);

        //var rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f, joystick.Vertical * 10f + Input.GetAxis("Vertical") * 10f, 0);

    }
}
