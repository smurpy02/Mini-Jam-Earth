using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int max;

    int health;

    public int currentHealth { get {  return health; } }

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
}
