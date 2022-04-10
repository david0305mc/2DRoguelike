using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectPool))]
public class Turret : MonoBehaviour
{
    [SerializeField] private List<Transform> turretBarrels = default; 
    public TurretData turretData;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    [SerializeField] private int bulletPoolCount = 10;
    [SerializeField] private ObjectPool bulletPool = default;

    [SerializeField] private UnityEvent OnShoot;
    [SerializeField] private UnityEvent OnReload;
    [SerializeField] private UnityEvent OnCantShoot;
    [SerializeField] private UnityEvent<float> OnReloading;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab.gameObject, bulletPoolCount);
        OnReloading?.Invoke(currentDelay);
    }

    private void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            OnReloading?.Invoke(currentDelay);
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = bulletPool.CreateObject();
                //GameObject bullet = Instantiate(bulletPrefab.gameObject);
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);
                foreach (var collier in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collier);
                }
            }
            OnShoot?.Invoke();
            OnReloading?.Invoke(currentDelay);
        }
        else
        {
            OnCantShoot?.Invoke();
        }
        Debug.Log("Shooting");
    }
}
