using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Audio _audio;
    [SerializeField] private EnemyPool[] _enemyPools;
    [SerializeField] private DeathParticlesPool _deathParticlesPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _spawnInterval;

    private float _timeBeforeSpawn;

    private void Start()
    {
        _timeBeforeSpawn = _spawnInterval;
    }

    private void Spawn()
    {
        if (_player.IsAlive == true)
        {
            int randomIndex = Random.Range(0, _enemyPools.Length);
            GameObject enemy = _enemyPools[randomIndex].GetObject();
            enemy.SetActive(true);
            enemy.transform.position = transform.position;
            enemy.GetComponent<Enemy>().Init(_player, _audio, _deathParticlesPool, _bulletPool);
        }
    }

    private void Update()
    {
        _timeBeforeSpawn -= Time.deltaTime;

        if (_timeBeforeSpawn <= 0)
        {
            Spawn();
            _timeBeforeSpawn = _spawnInterval;
        }
    }
}
