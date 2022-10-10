using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Air
{
    


    private float _targetX;
    private float _jumpUpRange;



    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        
        base.Enter();

        _jumpUpRange = sm.gameObject.transform.position.y + sm.characterStats.horizontalJumpRange;
        if (sm.movingState.jumpType == Moving.JumpType.LeftJump)
        {
            sm.anim.SetBool("JumpLeft", true);
            sm.anim.SetFloat("RandomAvoidAnimValue", Random.Range(0, 2));
            _targetX = sm.gameObject.transform.position.x - sm.characterStats.horizontalJumpRange;


        }
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {
            sm.anim.SetBool("JumpRight", true);
            sm.anim.SetFloat("RandomAvoidAnimValue", Random.Range(0, 2));
            _targetX = sm.gameObject.transform.position.x + sm.characterStats.horizontalJumpRange;

        }
        if (sm.movingState.jumpType==Moving.JumpType.UpJump)
        {
            sm.anim.SetFloat("RandomJumpAnimValue", Random.Range(0, 2));
            sm.anim.SetBool("JumpUp", true);
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
        JumpUp();
      


    }
    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpLeft", false);
        sm.anim.SetBool("JumpRight", false);
        sm.anim.SetBool("JumpUp", false);
    }

    private void JumpSide()
    {
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {


            
            Vector3 targetVec = new Vector3(_targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z);
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


            
            Vector3 targetVec = new Vector3(_targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z);
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

    private void JumpUp()
    {
        if (sm.movingState.jumpType==Moving.JumpType.UpJump)
        {
            sm.rb.useGravity = false;
            Vector3 targetVec = new Vector3(sm.gameObject.transform.position.x, _jumpUpRange, sm.gameObject.transform.position.z);
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.verticalJumpSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(sm.gameObject.transform.position,targetVec)<0.1f)
            {
                sm.gameObject.transform.position = targetVec;
            }
            if (sm.gameObject.transform.position==targetVec)
            {
                sm.ChangeState(sm.movingState);
                sm.rb.useGravity = true;
            }


        }
    }










}

