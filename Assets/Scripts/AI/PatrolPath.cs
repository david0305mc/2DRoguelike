using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public List<Transform> patrolPoints = new List<Transform>();

    public int Length { get => patrolPoints.Count; }

    [Header("Gizmos parameters")]
    public Color pointsColor = Color.blue;
    public float pointsSize = 0.3f;
    public Color lineColor = Color.magenta;

    private void OnDrawGizmos()
    {
        if (patrolPoints.Count == 0)
            return;

        for (int i = patrolPoints.Count - 1; i > 0; i--)
        {
            if (patrolPoints[i] == null)
                return;

            Gizmos.color = pointsColor;
            Gizmos.DrawSphere(patrolPoints[i].position, pointsSize);

            if (patrolPoints.Count == 1 || i == 0)
                return;

            Gizmos.color = lineColor;
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i - 1].position);

            //if (patrolPoints.Count > 2 && i == patrolPoints.Count - 1)
            //{
            //    Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
            //}
        }
    }


}
