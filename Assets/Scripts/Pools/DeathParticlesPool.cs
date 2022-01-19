using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticlesPool : ObjectPool
{
    [SerializeField] private ParticleSystem _deathParticlesPrefab;

    private void Start()
    {
        Initialize(_deathParticlesPrefab.gameObject);
    }
}
