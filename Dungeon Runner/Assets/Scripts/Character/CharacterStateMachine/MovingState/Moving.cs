using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{

    private MovementSM _stateMachine;

    private float _speed;
    private Rigidbody _rb;
    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {}

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public override void Enter()
    {
        base.Enter();
        _speed = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _speed = _rb.velocity.magnitude;
        if (_speed <Mathf.Epsilon)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
    }
}
