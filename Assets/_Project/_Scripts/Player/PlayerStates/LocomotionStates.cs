using UnityEngine;
public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _playerStateMachine.PlayerMovement.MovePlayer();

        if (_playerStateMachine.PlayerInputHandler.MovementInput.magnitude <= 0 
            && !PlayerProperties.IsJumping)
        {
            _playerStateMachine.LocomotionStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);
        }

    }
}

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {

        if (_playerStateMachine.PlayerInputHandler.MovementInput.magnitude > 0.1f)
        {
            _playerStateMachine.LocomotionStateMachine.ChangeState(_playerStateMachine.PlayerMovingState);
        }

    }
}
