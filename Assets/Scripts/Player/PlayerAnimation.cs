using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private const string IsGrounded = "IsGrounded";
    private const string Shoot = "Shoot";
    private const string Death = "Death";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetJumpAnimationBool(bool isGrounded)
    {
        _animator.SetBool(IsGrounded, isGrounded);
    }

    public void TriggerShootAnimation()
    {
        _animator.SetTrigger(Shoot);
    }

    public void TriggerDeathAnimation()
    {
        _animator.SetTrigger(Death);
    }
}
