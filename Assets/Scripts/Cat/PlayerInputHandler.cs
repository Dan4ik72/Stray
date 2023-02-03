using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover) , (typeof(PlayerJumper)))]
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InteractionCatcher _interactionCatcher;

    private PlayerInputMap _playerInput;
    private PlayerMover _playerMover;
    private PlayerJumper _playerJumper;

    private void Awake()
    {
        _playerInput = new PlayerInputMap();

        _playerInput.CharacterController.Jump.performed += ctx => OnJump();
        _playerInput.CharacterController.Interact.performed += ctx => _interactionCatcher.OnInteract();

        _playerMover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void FixedUpdate()
    {
        Vector2 direction = _playerInput.CharacterController.Movement.ReadValue<Vector2>();

        _playerMover.Move(direction);
    }

    public void EnableInput()
    {
        _playerInput.Enable();
    }

    public void DisableInput()
    {
        _playerInput.Disable();
    }

    private void OnJump()
    {
        _playerJumper.Jump();
    }
}
