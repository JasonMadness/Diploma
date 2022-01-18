using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TitleScreen _titleScreen;
    [SerializeField] private Button _returnToTitle;
    [SerializeField] private Player _player;
    [SerializeField] private Audio _audio;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private ObjectPool[] _pools;

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        StartCoroutine(Reveal());
    }

    private IEnumerator Reveal()
    {
        Time.timeScale = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(0.05f);

        while (Time.timeScale < 1)
        {
            if (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += 0.1f;
            }

            Time.timeScale += 0.05f;
            yield return delay;
        }

        _returnToTitle.gameObject.SetActive(true);
    }

    public void ReturnToTitleScreen()
    {
        _player.gameObject.SetActive(false);
        _level.SetActive(false);
        ResetAllPools();
        _enemySpawner.SetActive(false);
        _audio.PlayBackgroundMusic();
        _canvasGroup.alpha = 0f;
        _returnToTitle.gameObject.SetActive(false);
        _titleScreen.gameObject.SetActive(true);
    }

    public void ResetAllPools()
    {
        foreach (ObjectPool pool in _pools)
        {
            pool.DeactivateAllObjects();
        }
    }
}
