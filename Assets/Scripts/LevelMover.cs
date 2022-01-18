using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelMover : Mover
{
    private float _repeatWidth;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    protected override void ResetPosition()
    {
        if (transform.position.x < _startPosition.x - _repeatWidth)
        {
            transform.position = _startPosition;
        }
    }
}
