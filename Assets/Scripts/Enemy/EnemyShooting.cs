using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _shootDelay;

    private Animator _animator;
    private float _waitingTime;
    private float _shootAnimationLength = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _waitingTime = _shootDelay;
    }

    public void Init(Player player, BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _player = player;
    }

    private IEnumerator Shoot()
    {
        _animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(_shootAnimationLength / 2);

        foreach (Transform shootPoint in _shootPoints)
        {
            _bulletPool.TryGetObject(out GameObject bullet);
            bullet.SetActive(true);
            bullet.transform.position = shootPoint.position;
        }
    }

    private void Update()
    {
        if (_shootPoints.Length > 0 && _player.IsAlive == true)
        {
            _waitingTime -= Time.deltaTime;

            if (_waitingTime < 0)
            {
                StartCoroutine(Shoot());
                _waitingTime = _shootDelay;
            }
        }
    }
}
