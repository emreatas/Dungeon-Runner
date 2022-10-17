using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : Alive
{
    
   public Dead(MovementSM stateMachine) : base("Dead", stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        sm.anim.SetBool("Dead", true);
        sm.anim.SetBool("Sliding", false);
        sm.anim.SetBool("JumpLeft", false);
        sm.anim.SetBool("JumpRight", false);
        sm.anim.SetBool("JumpUp", false);
    }
}
