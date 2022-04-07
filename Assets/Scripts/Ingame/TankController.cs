using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
 
    [SerializeField] private TankMover tankMover;
    [SerializeField] private AimTurret aimTurret;
    [SerializeField] private Turret turret;

    public void HandleShoot()
    {
        turret.Shoot();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);
    }

}
