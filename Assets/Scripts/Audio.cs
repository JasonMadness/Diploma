using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _background;
    [SerializeField] private AudioSource _playerShot;
    [SerializeField] private AudioSource _playerDeath;
    [SerializeField] private AudioSource _playerHit;
    [SerializeField] private AudioSource _enemyHit;

    public void PlayBackgroundMusic()
    {
        _background.Play();
    }

    public void StopBackgroundMusic()
    {
        _background.Stop();
    }

    public void PlayEnemyHitSound()
    {
        _enemyHit.Play();
    }

    public void PlayPlayerShotSound()
    {
        _playerShot.Play();
    }

    public void PlayPlayerHitSound()
    {
        _playerHit.Play();
    }

    public void PlayPlayerDeathSound()
    {
        _playerDeath.Play();
    }
}
