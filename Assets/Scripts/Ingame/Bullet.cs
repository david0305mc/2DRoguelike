using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 startPosition;
    private float conquaredDistance = 0;
    [SerializeField] private Rigidbody2D rb2d;
    private BulletData bulletData;
    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * bulletData.speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DiableObject();
        }
    }

    private void DiableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider " + collision.name);

        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(bulletData.damage);
        }
        DiableObject();
    }
}
