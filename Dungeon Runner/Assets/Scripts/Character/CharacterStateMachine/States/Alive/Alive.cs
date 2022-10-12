using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : BaseState
{

    protected MovementSM sm;

    public bool gravityEnable=true;
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
    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
        Gravity();
    }


    private void Gravity()
    {
        if (!sm.isGrounded && gravityEnable)
        {
            sm.transform.position = new Vector3(sm.gameObject.transform.position.x, sm.gameObject.transform.position.y - 1 * 9.81f * Time.fixedDeltaTime, sm.gameObject.transform.position.z);
        }
    }
}