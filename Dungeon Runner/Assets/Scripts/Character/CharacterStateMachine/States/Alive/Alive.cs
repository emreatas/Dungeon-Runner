using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : BaseState
{

    protected MovementSM sm;
    public Alive(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();


        RaycastHit hit;

        //Debug.Log("giriyorum Grounded");
        if (Physics.Raycast(sm.gameObject.transform.position, -sm.gameObject.transform.up, out hit, sm.characterStats.groundCheckDistance))
        {
            sm.isGrounded = true;
        }
        else
        {
            sm.isGrounded = false;
        }


    }
}
