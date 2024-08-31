using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;
    public AudioSource fireSound;

    float nextFire;

    void Start()
    {
        nextFire = Time.time + fireRate;
    }

    private void Update()
    {
        if(nextFire > Time.time)
        {
            return;
        }

        nextFire = Time.time + fireRate;

        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();

        if(enemies.Length <= 0)
        {
            return;
        }

        Transform closestEnemy = null;
        float closestEnemyDistance = 0;

        foreach(EnemyHealth enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, transform.position);

            if(distance < closestEnemyDistance || closestEnemy == null)
            {
                closestEnemy = enemy.transform;
                closestEnemyDistance = distance;
            }
        }

        //var dir = closestEnemy.position - transform.position;
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Rotations.GetRotation(transform.position, closestEnemy.position);//Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(projectile, transform.position, transform.rotation);
        fireSound.Play();
    }
}
