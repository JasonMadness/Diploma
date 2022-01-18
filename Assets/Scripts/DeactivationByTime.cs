using UnityEngine;

public class DeactivationByTime : MonoBehaviour
{
    [SerializeField] private float _delay;

    private float _time;

    private void OnEnable()
    {
        _time = _delay;
    }

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
