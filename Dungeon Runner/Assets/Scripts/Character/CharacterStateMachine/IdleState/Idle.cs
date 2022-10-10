using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{

   

    

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) { 
    
      
    }

    public override void Enter()
    {
        base.Enter();
       
       
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        stateMachine.ChangeState(sm.movingState);
        /* if (Mathf.Abs (sm.rb.velocity.magnitude)>Mathf.Epsilon)
         {

         }*/


    }

}
