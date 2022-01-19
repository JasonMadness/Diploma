using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyShooting))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Vector3 _particlesOffset;

    private Player _player;
    private Audio _audio;
    private DeathParticlesPool _deathParticlesPool;
    private int _currentHealth;

    public event UnityAction<int> EnemyDied;

    public void Init(Player player, Audio audio, DeathParticlesPool deathParticlesPool, BulletPool bulletPool)
    {
        _player = player;
        _audio = audio;
        _deathParticlesPool = deathParticlesPool;
        EnemyDied += _player.OnEnemyDied;
        _currentHealth = _health;
        GetComponent<EnemyShooting>().Init(player, bulletPool);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Boundary _))
        {
            EnemyDied -= _player.OnEnemyDied;
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        _currentHealth--;
        _audio.PlayEnemyHitSound();

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        GameObject deathParticles = _deathParticlesPool.GetObject();
        deathParticles.SetActive(true);
        deathParticles.transform.position = transform.position + _particlesOffset;
        EnemyDied?.Invoke(_reward);
        EnemyDied -= _player.OnEnemyDied;
        gameObject.SetActive(false);
    }
}
