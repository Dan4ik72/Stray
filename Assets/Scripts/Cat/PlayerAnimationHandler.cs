using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMover _playerMover;

    private int _speedParameterHash = Animator.StringToHash("speed");

    private void Update()
    {
        _animator.SetFloat(_speedParameterHash, Mathf.Abs(_playerMover.CurrentSpeed)); 
    }
}
