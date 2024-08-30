using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemies
{
    public float spawnRate;
    public float spawnIncreaseRate;
    public float minSpawnRate;

    public GameObject enemy;
    public float firstSpawn;

    public float nextSpawn;
}
