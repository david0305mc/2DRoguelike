using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDefaultEnemy : MonoBehaviour
{
    [SerializeField] private AIBehaviour shootBehaviour;
    [SerializeField] private AIBehaviour patrolbehaviour;

    [SerializeField] private TankController tank;
    [SerializeField] private AIDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (detector.TargetVisible)
        {
            shootBehaviour.PerformAction(tank, detector);
        }
        else
        { 
        
        }
    }


}
