using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Audio _audio;

    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Shoot()
    {
        _isGrounded = Mathf.Abs(_rigidbody.velocity.y) < 0.01f;

        if (_isGrounded && _bulletPool.TryGetObject(out GameObject bullet))
        {
            _audio.PlayPlayerShotSound();
            bullet.SetActive(true);
            bullet.transform.position = _shootPoint.position;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _player.IsAlive == true)
        {
            Shoot();
            _playerAnimation.TriggerShootAnimation();
        }
    }
}
