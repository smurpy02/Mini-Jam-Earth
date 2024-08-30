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
            enemy.nextSpawn = Time.time + enemy.firstSpawn;
        }
    }

    void Update()
    {
        foreach (var enemy in enemySpawners)
        {
            if (enemy.nextSpawn <= Time.time)
            {
                enemy.nextSpawn = Time.time + enemy.spawnRate;

                Vector3 randomDir = Random.insideUnitCircle.normalized;

                Instantiate(enemy.enemy, transform.position + randomDir*0.4f, Rotations.GetRotation(Vector3.zero, randomDir));

                enemy.spawnRate = Mathf.Clamp(enemy.spawnRate * enemy.spawnIncreaseRate, enemy.minSpawnRate, Mathf.Infinity);
            }
        }
    }
}
