using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;
    [SerializeField] private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthchange?.Invoke(Health);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthchange;
    public UnityEvent OnHit;
    public UnityEvent OnHeal;

    private void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHeal?.Invoke();
        }
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }

}
