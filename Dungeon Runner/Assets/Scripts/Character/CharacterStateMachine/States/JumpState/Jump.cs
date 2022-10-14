using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Air
{


    private bool _reachedPos;
    private bool _canJump;

    private float _jumpUpRange;
   


    private float targetX;


    private Vector3 _colliderFirstCenterPos;
    private float _colliderFirstHeight;



    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {

    }

    public override void Enter()
    {

        base.Enter();
        sm.rb.useGravity = false;
        _canJump = sm.isGrounded;
        _colliderFirstCenterPos = sm.characterCollider.center;
        _colliderFirstHeight = sm.characterCollider.height;
        _jumpUpRange = sm.gameObject.transform.position.y + sm.characterStats.horizontalJumpRange;
        targetX = sm.gameObject.transform.position.x;
        gravityMultipler = 1;
        sm.anim.SetFloat("RandomJumpAnimValue", Random.Range(0, 2));
        sm.anim.SetBool("JumpUp", true);
        sm.trailEffect.isTrailActive = true;
        sm.characterCollider.height = 0.5f;
        sm.characterCollider.center = new Vector3(sm.characterCollider.center.x, 1.5f, sm.characterCollider.center.z);


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
        Debug.Log("jumpexit1");
        _reachedPos = false;
        //jumpType = JumpType.Base;
        sm.characterCollider.height = _colliderFirstHeight;
        sm.characterCollider.center = _colliderFirstCenterPos;
       
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
            sm.characterCollider.height = _colliderFirstHeight;
            sm.characterCollider.center = _colliderFirstCenterPos;

            if (sm.isGrounded)
            {
                sm.ChangeState(sm.movingState);
                
            }


        }



    }

 


}











