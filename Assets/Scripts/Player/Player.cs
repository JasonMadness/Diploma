using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Audio _audio;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private int _score;
    private bool _isAlive;

    public bool IsAlive => _isAlive;

    public event UnityAction PlayerDied;
    public event UnityAction<int> ScoreChanged;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        _isAlive = true;
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audio.PlayPlayerHitSound();
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _isAlive = false;
        DisableComponents();
        _playerAnimation.TriggerDeathAnimation();
        Time.timeScale = 0.1f;
        _audio.StopBackgroundMusic();
        yield return new WaitForSeconds(0.2f);
        _audio.PlayPlayerDeathSound();
        PlayerDied?.Invoke();
    }

    public void EnableComponents()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    private void DisableComponents()
    {
        _collider.enabled = false; 
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }

    public void OnEnemyDied(int reward)
    {
        _score += reward;
        ScoreChanged?.Invoke(_score);
    }
}
