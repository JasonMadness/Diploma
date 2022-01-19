using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _shootDelay = 0.5f;

    private Animator _animator;
    private float _waitingTime;

    public const string Shoot = "Shoot";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _waitingTime = _shootInterval;
    }

    public void Init(Player player, BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _player = player;
    }

    private IEnumerator MakeShot()
    {
        _animator.SetTrigger(Shoot);
        yield return new WaitForSeconds(_shootDelay);

        foreach (Transform shootPoint in _shootPoints)
        {
            GameObject bullet = _bulletPool.GetObject();
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
                StartCoroutine(MakeShot());
                _waitingTime = _shootInterval;
            }
        }
    }
}
