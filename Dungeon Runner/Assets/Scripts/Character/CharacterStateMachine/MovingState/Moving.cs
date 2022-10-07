using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{

    protected MovementSM sm;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
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
        stateMachine.ChangeState(sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

    }
}
