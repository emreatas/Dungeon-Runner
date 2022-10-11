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
    public Dash dashState;
    [HideInInspector]
    public Sliding slidingState;



    
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
        dashState = new Dash(this);
        slidingState = new Sliding(this);
       
    }
  

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
