using UnityEngine;

public class PlayerAiredState : EntityState
{
    public PlayerAiredState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine,
        animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0)
        {
            player.SetVelocity(player.moveInput.x * (player.moveSpeed * player.inAirMoveMultiplier),
                rb.linearVelocity.y);
        }

        if (input.Player.Jump.WasPressedThisFrame() && player.jumpCount < player.maxJumpCount)
        {
            player.jumpCount++;
            stateMachine.ChangeState(player.jumpState);
        }

        if (input.Player.Attack.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.basicAttackState);
        }
    }
}