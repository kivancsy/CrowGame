using UnityEngine;

public class PlayerFallState : PlayerAiredState
{
    public PlayerFallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine,
        animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.groundDetected && rb.linearVelocity.x == 0f)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (player.groundDetected && rb.linearVelocity.x != 0f)
        {
            stateMachine.ChangeState(player.moveState);
        }

        if (player.wallDetected)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }
}