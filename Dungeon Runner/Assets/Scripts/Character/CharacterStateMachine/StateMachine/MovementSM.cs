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



    
    public Rigidbody rb;
    public CharacterStatsScriptable characterStats;
    public Animator anim;

   

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jump(this);
       
    }
   

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
