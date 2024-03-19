using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float currentWaveTime;
    float waveProgressToSpawn => currentWaveTime/10f;
    ObjectPool enemyPool;
    [SerializeField] IPoolable enemy;
    private void Start()
    {
        enemyPool = ObjectPool.CreateInstance(enemy, 20);
    }
    void SpawnEnemies()
    {

    }
}
