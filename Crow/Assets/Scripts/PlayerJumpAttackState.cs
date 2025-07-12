using UnityEngine;

public class PlayerJumpAttackState : EntityState
{
    public PlayerJumpAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.wallJumpDirection.x * -player.facingDirection, player.wallJumpDirection.y);
    }

    public override void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }

        if (rb.linearVelocity.y > 0 && input.Player.Attack.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.jumpAttackState);
        }

        if (player.wallDetected)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }
}