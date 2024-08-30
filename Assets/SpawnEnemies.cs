using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float spawnRate;
    public GameObject enemy;
    public bool spawnAtStart = false;

    float nextSpawn;

    void Start()
    {
        if(!spawnAtStart) nextSpawn = Time.time + spawnRate;
    }

    void Update()
    {
        if(nextSpawn <= Time.time)
        {
            nextSpawn = Time.time + spawnRate;

            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
