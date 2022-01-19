using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;

    private void Start()
    {
        Initialize(_enemyPrefab.gameObject);
    }
}
