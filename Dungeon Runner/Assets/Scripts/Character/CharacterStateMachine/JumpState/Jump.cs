using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Air
{


    private bool _reachedPos;

    private float _jumpUpRange;

    private Vector3 _characterFirstPos;


    public Jump(MovementSM stateMachine) : base("Jump", stateMachine)
    {

    }

    public override void Enter()
    {

        base.Enter();
        _characterFirstPos = sm.gameObject.transform.position;
        _jumpUpRange = sm.gameObject.transform.position.y + sm.characterStats.horizontalJumpRange;

        if (sm.movingState.jumpType == Moving.JumpType.UpJump)
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

        JumpUp();


    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
    }
    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpUp", false);
    }



    private void JumpUp()
    {
        if (!_reachedPos)
        {
            if (sm.movingState.jumpType == Moving.JumpType.UpJump)
            {
                Vector3 targetVec = new Vector3(sm.gameObject.transform.position.x, _jumpUpRange, sm.gameObject.transform.position.z);
                sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.verticalJumpSpeed * Time.fixedDeltaTime);
                if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
                {
                    sm.gameObject.transform.position = targetVec;
                    _reachedPos = true;
                }

            }
        }
        else
        {
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, new Vector3(sm.gameObject.transform.position.x,_characterFirstPos.y,sm.gameObject.transform.position.z), 9.81f*Time.deltaTime);
            if (sm.gameObject.transform.position.y-_characterFirstPos.y<0.1f)
            {
                _reachedPos = false;
                Debug.Log("Change State");
                sm.ChangeState(sm.movingState);
                
            }

            

        }
      


    }











}

