using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage;
    public bool destroyOnDamage;

    List<Collider2D> damaged = new List<Collider2D>();

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<GoalHealth>() != null)
        {
            return;
        }

        Health health = other.GetComponentInChildren<Health>();

        if (health != null)
        {
            if(damaged.Contains(other))
            {
                return;
            }

            damaged.Add(other);
            health.Damage(damage);
            Damage();
            if (destroyOnDamage) Destroy(gameObject);
        }
    }

    void OnDisable()
    {
        damaged.Clear();
    }

    public virtual void Damage()
    {

    }
}
