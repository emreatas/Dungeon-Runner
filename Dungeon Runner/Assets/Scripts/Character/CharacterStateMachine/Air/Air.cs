using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : BaseState
{
    protected MovementSM sm;
    public Air(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }


    public override void Enter()
    {
        base.Enter();
    }


    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
