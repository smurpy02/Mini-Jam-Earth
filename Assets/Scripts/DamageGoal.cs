using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGoal : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GoalHealth goal = collision.transform.GetComponent<GoalHealth>();

        if (goal != null)
        {
            goal.Damage(damage);
            Destroy(gameObject);
        }
    }
}
