using UnityEngine;

public class PlayerBasicAttackState : EntityState
{
    public PlayerBasicAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    private float attackVelocityTimer;
    private int attackDirection;

    public override void Enter()
    {
        base.Enter();
        attackDirection = player.moveInput.x != 0 ? ((int)player.moveInput.x) : player.facingDirection;

        ApplyAttackVelocity();
        triggerCalled = false;
    }

    public override void Update()
    {
        base.Update();
        HandleAttackVelocity();
    }

    private void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;

        if (attackVelocityTimer < 0)
            player.SetVelocity(0, rb.linearVelocity.y);
        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    private void ApplyAttackVelocity()
    {
        Vector2 attackVelocity = player.attackVelocity;
        attackVelocityTimer = player.attackVelocityDuration;
        player.SetVelocity(attackVelocity.x * attackDirection, attackVelocity.y);
    }
}