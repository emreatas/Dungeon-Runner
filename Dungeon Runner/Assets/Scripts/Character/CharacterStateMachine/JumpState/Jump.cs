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
       
       
        if (sm.movingState.jumpType==Moving.JumpType.LeftJump)
        {
            sm.anim.SetBool("JumpLeft", true);
            targetX = sm.gameObject.transform.position.x-5f;


        }
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {
            sm.anim.SetBool("JumpRight", true);
            targetX = sm.gameObject.transform.position.x + 5f;

        }
        

        
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (sm.movingState.jumpType == Moving.JumpType.RightJump)
        {
            

            Debug.Log("girdim right jump");
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, new Vector3(targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z), sm.characterStats.horizontalJumpSpeed * Time.deltaTime);


        }
        if (sm.movingState.jumpType == Moving.JumpType.LeftJump)
        {
            

            Debug.Log("girdim right jump");
            sm.gameObject.transform.position = Vector3.Lerp(sm.gameObject.transform.position, new Vector3(targetX, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z), sm.characterStats.horizontalJumpSpeed * Time.deltaTime);


        }


    }
    IEnumerator JumpFrame()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        sm.ChangeState(sm.movingState);

    }
    public override void Exit()
    {
        base.Exit();
        sm.anim.SetBool("JumpLeft", false);
        sm.anim.SetBool("JumpRight", false);
    }

    private void MoveSide(Moving.JumpType jumpType, int distance)
    {
        if (jumpType==Moving.JumpType.RightJump)
        {
            float target = sm.gameObject.transform.position.x + distance;
            
                Debug.Log("girdim right jump");
                sm.gameObject.transform.position = Vector3.MoveTowards(sm.gameObject.transform.position, new Vector3(target, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z),sm.characterStats.horizontalJumpSpeed*Time.deltaTime);
            
            
        }
        if (jumpType == Moving.JumpType.LeftJump)
        {
            float target= sm.gameObject.transform.position.x - distance;
            
                Debug.Log("girdim right jump");
                sm.gameObject.transform.position = Vector3.MoveTowards(sm.gameObject.transform.position, new Vector3(target, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z), sm.characterStats.horizontalJumpSpeed * Time.deltaTime);
            
            
        }
    }


    







}

