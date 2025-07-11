using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string animBoolName;
    
    protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInputSet input;

    public EntityState(Player player, StateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;

        anim = player.anim;
        input = player.input;
    }

    public virtual void Enter()
    {
        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        
    }
    
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
