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



    
    public Rigidbody rb;
    public CharacterStatsScriptable characterStats;
    public Animator anim;
    public bool isGrounded;

   

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jump(this);
        dashState = new Dash(this);
       
    }
  

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
