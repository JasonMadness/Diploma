using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }
}
