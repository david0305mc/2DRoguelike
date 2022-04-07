using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private List<Transform> turretBarrels; 
    [SerializeField] private Bullet bulletPrefab;

    public float reloadDelay = 1;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
    }

    private void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
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
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = Instantiate(bulletPrefab.gameObject);
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize();
                foreach (var collier in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collier);
                }
            }
        }
        Debug.Log("Shooting");
    }
}
