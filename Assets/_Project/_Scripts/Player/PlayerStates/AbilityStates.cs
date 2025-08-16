using UnityEngine;

public class PlayerInvisibleState : PlayerState
{
    public PlayerInvisibleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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
        if(!PlayerProperties.IsInvisible) 
            _playerStateMachine.AbilityStateMachine.ChangeState(_playerStateMachine.PlayerNoneState);
    }
}
public class PlayerNoneState : PlayerState
{
    public PlayerNoneState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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
        if (PlayerProperties.IsInvisible) 
            _playerStateMachine.AbilityStateMachine.ChangeState(_playerStateMachine.PlayerInvisibleState);
    }
}
