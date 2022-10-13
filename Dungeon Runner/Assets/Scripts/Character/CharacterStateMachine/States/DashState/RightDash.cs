using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDash : Alive
{
    private float _targetX;
    public RightDash(MovementSM stateMachine) : base("RightDash", stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.OnDashRight();
        if (sm.isGrounded)
        {
            
            sm.anim.SetFloat("RandomAvoidAnimValue", Random.Range(0, 2));
        }
        else
        {
            sm.anim.SetFloat("RandomAvoidAnimValue", 2);
        }
        sm.anim.SetBool("JumpRight", true);

        _targetX = sm.gameObject.transform.position.x + sm.characterStats.horizontalJumpRange;
    }

    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
        JumpSide();
    }

    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpRight", false);

    }

    public void JumpSide()
    {



        Debug.Log("kontroll");

        Vector3 targetVec = new Vector3(_targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z);
        sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.horizontalJumpSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
        {
            sm.gameObject.transform.position = targetVec;
        }
        if (sm.gameObject.transform.position == targetVec&&sm.isGrounded)
        {
            sm.ChangeState(sm.movingState);
        }




    }

}
