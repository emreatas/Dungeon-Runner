using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{

    private MovementSM _stateMachine;
    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {

        _stateMachine = stateMachine;
    }
}
