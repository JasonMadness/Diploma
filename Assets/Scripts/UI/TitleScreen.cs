using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _level;
    [SerializeField] private EnemySpawner _enemySpawner;

    public void StartNewGame()
    {
        _player.gameObject.SetActive(true);
        _player.GetComponent<Player>().EnableComponents();
        _level.SetActive(true);
        _enemySpawner.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}