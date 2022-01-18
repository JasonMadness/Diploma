using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Direction _directions;

    private Vector3 _direction;

    private void Awake()
    {
        if (_directions == Direction.Left)
        {
            _direction = Vector3.left;
        }
        else
        {
            _direction = Vector3.right;
        }
    }

    protected virtual void ResetPosition()
    {

    }

    private void Update()
    {      
        transform.Translate(_direction * _speed * Time.deltaTime);
        ResetPosition();
    }

    protected enum Direction
    {
        Left,
        Right
    };
}
