using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Grounded
{
   
  
    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        //jumpType = JumpType.Base;
  



    }
    



    public override void Exit()
    {
        base.Exit();
        //jumpType = JumpType.Base;


    }

   

}
