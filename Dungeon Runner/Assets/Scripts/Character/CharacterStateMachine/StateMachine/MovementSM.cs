using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jump jumpingState;
    [HideInInspector]
    public Sliding slidingState;
    [HideInInspector]
    public LeftDash leftDashState;
    [HideInInspector]
    public RightDash rightDashState;





    public Rigidbody rb;
    public CharacterStatsScriptable characterStats;
    public Animator anim;
    public CapsuleCollider characterCollider;
    public bool isGrounded;



    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jump(this);
        slidingState = new Sliding(this);
        leftDashState = new LeftDash(this);
        rightDashState = new RightDash(this);

    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
