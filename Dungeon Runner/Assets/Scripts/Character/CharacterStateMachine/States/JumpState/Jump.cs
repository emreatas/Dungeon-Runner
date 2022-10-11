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
    }



    private void JumpUp()
    {
        if (!_reachedPos)
        {
            
                Vector3 targetVec = new Vector3(sm.gameObject.transform.position.x, _jumpUpRange, sm.gameObject.transform.position.z);
                sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, targetVec, sm.characterStats.verticalJumpSpeed * Time.fixedDeltaTime);
                if (Vector3.Distance(sm.gameObject.transform.position, targetVec) < 0.1f)
                {
                    sm.gameObject.transform.position = new Vector3(sm.gameObject.transform.position.x, targetVec.y, sm.gameObject.transform.position.z);
                    _reachedPos = true;
                }

            
        }
        else
        {
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, new Vector3(sm.gameObject.transform.position.x,_characterFirstPos.y,sm.gameObject.transform.position.z), 9.81f*Time.fixedDeltaTime);
            if (sm.gameObject.transform.position.y-_characterFirstPos.y<0.1f)
            {
                sm.gameObject.transform.position = new Vector3(sm.gameObject.transform.position.x, _characterFirstPos.y, sm.gameObject.transform.position.z);

                sm.ChangeState(sm.movingState);
                

            }

            

        }
      


    }











}

