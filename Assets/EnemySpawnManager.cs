using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<SpawnEnemies> enemySpawners;

    void Start()
    {
        foreach(var enemy in enemySpawners)
        {
            enemy.nextSpawn = enemy.spawnAtStart ? 0 : Time.time + enemy.spawnRate;
        }
    }

    void Update()
    {
        foreach (var enemy in enemySpawners)
        {
            if (enemy.nextSpawn <= Time.time)
            {
                enemy.nextSpawn = Time.time + enemy.spawnRate;

                Instantiate(enemy.enemy, transform.position, transform.rotation);

                enemy.spawnRate = Mathf.Clamp(enemy.spawnRate * enemy.spawnIncreaseRate, enemy.minSpawnRate, Mathf.Infinity);
            }
        }
    }
}
