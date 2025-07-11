using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }
    private StateMachine stateMachine;
    public Rigidbody2D rb { get; private set; }
    public PlayerInputSet input { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    [Header("Movement")] public float moveSpeed = 8f;
    private bool facingRight = true;
    public int facingDirection { get; private set; } = 1;
    public Vector2 moveInput { get; private set; }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = gameObject.AddComponent<StateMachine>();
        input = new PlayerInputSet();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => moveInput = (ctx.ReadValue<Vector2>());
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }

    private void HandleFlip(float xVelocity)
    {
        if (xVelocity > 0 && !facingRight)
            Flip();
        else if (xVelocity < 0 && facingRight)
            Flip();
    }

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDirection = facingDirection * -1;
    }
}