using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeedWhileOffTheGround;

    private PlayerMover _playerMover;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _groundChecker.OffTheGround += SetMoveSpeedWhileJumping;
        _groundChecker.Landed += SetDefaultMoveSpeed;
    }

    private void OnDisable()
    {
        _groundChecker.OffTheGround -= SetMoveSpeedWhileJumping;
        _groundChecker.Landed -= SetDefaultMoveSpeed;
    }

    private void Update()
    {
        SetDrag();
    }

    public void Jump()
    {
        if (_groundChecker.IsOnTheGround)
            _rigidbody.velocity += new Vector3(0, _jumpForce, 0);
    }

    private void SetMoveSpeedWhileJumping()
    {
        if (_groundChecker.IsOnTheGround == false)
            _playerMover.SetSpeed(_moveSpeedWhileOffTheGround);
    }

    private void SetDefaultMoveSpeed()
    {
        if (_groundChecker.IsOnTheGround == true)
            _playerMover.SetSpeed(_playerMover.DefaultMoveSpeed);
    }

    private void SetDrag()
    {
        if (_groundChecker.IsOnTheGround)
            _rigidbody.drag = 20;
        else
            _rigidbody.drag = 0;
    }
}
