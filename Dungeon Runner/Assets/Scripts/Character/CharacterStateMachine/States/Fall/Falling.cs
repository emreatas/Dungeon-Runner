using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : Air
{
   public Falling(MovementSM stateMachine) : base("Falling", stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (sm.isGrounded)
        {
            sm.ChangeState(sm.movingState);
        }
    }
}
