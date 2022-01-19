using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private GameObject _prefab;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _prefab = prefab;

        for (int i = 0; i < _capacity; i++)
        {
            CreateNewObject();
        }
    }

    public GameObject GetObject()
    {
        if (TryGetObject(out GameObject result))
        {
            return result;
        }
        else
        {
            CreateNewObject();
            return GetLastObject();
        }
    }

    private void CreateNewObject()
    {
        GameObject spawned = Instantiate(_prefab, _container);
        spawned.SetActive(false);
        _pool.Add(spawned);
    }

    private GameObject GetLastObject()
    {
        return _pool.Last();
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(poolObject => poolObject.activeSelf == false);
        return result != null;
    }

    public void DeactivateAllObjects()
    {
        foreach (GameObject poolObject in _pool)
        {
            poolObject.SetActive(false);
        }
    }
}
