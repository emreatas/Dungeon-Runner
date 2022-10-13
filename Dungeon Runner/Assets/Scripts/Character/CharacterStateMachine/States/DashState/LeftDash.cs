using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDash : Alive
{
    private float _targetX;
    public LeftDash(MovementSM stateMachine) : base("LeftDash", stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.OnDashLeft();
        if (sm.isGrounded)
        {
            
            sm.anim.SetFloat("RandomAvoidAnimValue", Random.Range(0, 2));
        }
        else
        {
            Debug.Log("else");
            sm.anim.SetFloat("RandomAvoidAnimValue", 2);
        }
        sm.anim.SetBool("JumpLeft", true);

        _targetX = sm.gameObject.transform.position.x - sm.characterStats.horizontalJumpRange;
    }

    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
        JumpSide();
    }

    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpLeft", false);


    }

    public void JumpSide()
    {

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
