using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        _isGrounded = Mathf.Abs(_rigidbody.velocity.y) < 0.005f;
        _playerAnimation.SetJumpAnimationBool(_isGrounded);
    }
}
