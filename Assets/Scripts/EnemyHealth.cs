using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject deathParticles;

    public GameObject fragment;
    public GameObject blueprint;

    public int maxFragmentsDropped;
    public int maxBlueprintsDropped;

    public AudioSource takeDamageSound;

    public override void Die()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);

        for(int i = 0; i < Random.Range(0, maxFragmentsDropped); i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Instantiate(fragment, transform.position, rotation);
        }

        for(int i = 0; i < Random.Range(0, maxBlueprintsDropped); i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Instantiate(blueprint, transform.position, rotation);
        }

        Destroy(gameObject);
    }

    public override void TakeDamage()
    {
        takeDamageSound.Play();
    }
}
