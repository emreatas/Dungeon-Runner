using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : BaseState
{
    protected MovementSM sm;


    private float targetX;



    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        sm.StartCoroutine(JumpFrame());
        base.Enter();


        if (sm.movingState.jumpType == Moving.JumpType.LeftJump)
        {
            sm.anim.SetBool("JumpLeft", true);
            targetX = sm.gameObject.transform.position.x - sm.characterStats.horizontalJumpRange;


        }
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {
            sm.anim.SetBool("JumpRight", true);
            targetX = sm.gameObject.transform.position.x + sm.characterStats.horizontalJumpRange;

        }




    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

    }
   

    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
        JumpSide();
      


    }
    IEnumerator JumpFrame()
    {
        yield return new WaitForSecondsRealtime(0.4f);
       

    }
    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpLeft", false);
        sm.anim.SetBool("JumpRight", false);
    }

    private void JumpSide()
    {
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {


            
            Vector3 targetVec = new Vector3(targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z);
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.horizontalJumpSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
            {
                sm.gameObject.transform.position = targetVec;
            }
            if (sm.gameObject.transform.position == targetVec)
            {
                sm.ChangeState(sm.movingState);
            }


        }
        if (sm.movingState.jumpType == Moving.JumpType.LeftJump)
        {


            
            Vector3 targetVec = new Vector3(targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z);
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.horizontalJumpSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
            {
                sm.gameObject.transform.position = targetVec;
            }
            if (sm.gameObject.transform.position == targetVec)
            {
                sm.ChangeState(sm.movingState);
            }

        }
    }










}

