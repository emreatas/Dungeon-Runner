using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{

    private MovementSM _stateMachine;
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) {
        _stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

}
