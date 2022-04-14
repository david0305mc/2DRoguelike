using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    [Range(1, 15)] [SerializeField] private float viewRadius = 11;
    [SerializeField] private float detectionCheckDelay = 0.1f;
    public Transform target = default;
    public TankController player = default;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private LayerMask visibilityLayer;

    [field: SerializeField]
    public bool TargetVisible { get; private set; }

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if (Target != null)
        {
            TargetVisible = CheckTargetVisible();
            Shoot();
        }    
    }


    private void Shoot()
    {
        //player.HandleMoveBody(Vector2.zero);
        //player.HandleShoot();

        player.HandleTurretMovement(Target.position);
        player.HandleShoot();
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }

    private void DetectTarget()
    {
        if (Target == null)
        {
            CheckIfPlayerInRange();
        }
        else
        {
            DetectIfOutOfrange();
        }
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (enemyLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void CheckIfPlayerInRange()
    {  
        var enemies =  Physics2D.OverlapCircleAll(transform.position, viewRadius, enemyLayerMask);
        if (enemies.Length > 0)
        {
            var items = enemies.OrderBy(obj =>
            {
                return Vector2.Distance(obj.gameObject.transform.position, transform.position);
            }).ToList();
            Target = items.First().transform;
        }
    }

    private void DetectIfOutOfrange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > viewRadius)
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
