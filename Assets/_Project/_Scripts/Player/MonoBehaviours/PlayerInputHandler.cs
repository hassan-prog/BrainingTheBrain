using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Vector2 _movementInput;

    public event Action OnJump;
    public event Action<AbilityType> OnAbilityUse;
    public event Action OnMove;
    public event Action OnAttack;

    public Vector2 MovementInput => _movementInput;


    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();

        // Player movement events
        _playerControls.PlayerMovement.Movement.performed += SetMovementInput;
        _playerControls.PlayerMovement.Movement.canceled += SetMovementInput;
        _playerControls.PlayerMovement.Jump.performed += PerformJump;

        // Player abilities events
        _playerControls.PlayerAbilities.Attack.performed += Attack;
        _playerControls.PlayerAbilities.invisibility.performed += PerformInvisibility;
    }


    private void OnDisable()
    {
        _playerControls.Disable();

        // Player movement events
        _playerControls.PlayerMovement.Movement.performed -= SetMovementInput;
        _playerControls.PlayerMovement.Movement.canceled -= SetMovementInput;
        _playerControls.PlayerMovement.Jump.performed -= PerformJump;

        // Player abilities events
        _playerControls.PlayerAbilities.Attack.performed -= Attack;
        _playerControls.PlayerAbilities.invisibility.performed -= PerformInvisibility;
    }

    private void SetMovementInput(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        OnMove?.Invoke();
    }

    private void PerformJump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void PerformInvisibility(InputAction.CallbackContext context)
    {
        OnAbilityUse?.Invoke(AbilityType.Invisibility);
    }

    private void Attack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }
}
