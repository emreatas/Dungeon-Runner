using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Air
{


    private bool _reachedPos;
    private bool _canJump;

    private float _jumpUpRange;
   


    private float targetX;

  

    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {

    }

    public override void Enter()
    {

        base.Enter();
        sm.rb.useGravity = false;
        _canJump = sm.isGrounded;
        _jumpUpRange = sm.gameObject.transform.position.y + sm.characterStats.horizontalJumpRange;
        targetX = sm.gameObject.transform.position.x;

        sm.anim.SetFloat("RandomJumpAnimValue", Random.Range(0, 2));
        sm.anim.SetBool("JumpUp", true);
        

    }


  

    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();

        JumpUp();
       


    }

    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpUp", false);
        _reachedPos = false;
        //jumpType = JumpType.Base;
    }



    private void JumpUp()
    {
        if (!_reachedPos && _canJump)
        {
            sm.rb.velocity = Vector3.zero;
            //gravityEnable = false;
            Vector3 targetVec = new Vector3(targetX, _jumpUpRange, sm.gameObject.transform.position.z);
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.verticalJumpSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
            {
                Debug.Log("eq");
                sm.gameObject.transform.position = new Vector3(targetX, targetVec.y, sm.gameObject.transform.position.z);
                _reachedPos = true;
                _canJump = false;
                gravityEnable = true;

            }


        }
        else
        {
            sm.rb.useGravity = true;

            if (sm.isGrounded)
            {
                sm.ChangeState(sm.movingState);
            }


        }



    }

 


}











