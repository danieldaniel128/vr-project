using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float _waveProgressToSpawn => _waveManager.waveTimer.initialTime / 10f;  //tenth of wave's time.
    ObjectPool _enemyPool;
    [SerializeField] Enemy _enemy;
    [SerializeField]  WaveManager _waveManager;
    [SerializeField] Transform _spawnArea;
    [SerializeField] Transform[] patrolPoints;
    private float lastLogTime = 0f;
    private void Start()
    {
        _enemyPool = ObjectPool.CreateInstance(_enemy, 20);
    }
    private void Update()
    {
        if ((1 - _waveManager.waveTimer.Progress) - lastLogTime >= 0.1f)//spawn every tenth
        {
            SpawnEnemies();
            lastLogTime = 1 - _waveManager.waveTimer.Progress;
        }
    }
    void SpawnEnemies()
    {
        Enemy spawnedEnemy = (_enemyPool.GetPooledObject() as Enemy);
        spawnedEnemy.gameObject.transform.position = _spawnArea.position;
        spawnedEnemy.SetAgentPatrolPoints(patrolPoints);
    }
}
