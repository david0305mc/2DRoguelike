using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60f;
    // Start is called before the first frame update
    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFov(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }
        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFov(TankController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.AimTurret.transform.position;
        if (Vector2.Angle(tank.AimTurret.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            return true;
        }

        return false;
    }
}
