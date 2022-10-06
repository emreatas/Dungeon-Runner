using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{

    private MovementSM _stateMachine;

    private Rigidbody _rb;
    private float _speed;
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) {}


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
        if (_speed>Mathf.Epsilon)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
    }
    
}
