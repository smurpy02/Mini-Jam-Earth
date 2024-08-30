using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int max;

    float health;

    public float currentHealth { get {  return health; } }

    private void Awake()
    {
        health = max;
    }

    public void Damage(int damage)
    {
        health -= damage;
        TakeDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }

    public virtual void TakeDamage()
    {

    }

    public void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, max);
    }
}
