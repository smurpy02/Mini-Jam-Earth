using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage;
    public bool destroyOnDamage;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<GoalHealth>() != null)
        {
            return;
        }

        Health health = other.GetComponentInChildren<Health>();

        if (health != null)
        {
            health.Damage(damage);
            if (destroyOnDamage) Destroy(gameObject);
        }
    }
}
