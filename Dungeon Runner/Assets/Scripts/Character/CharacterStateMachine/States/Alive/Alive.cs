using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : BaseState
{

    protected MovementSM sm;

    public bool gravityEnable = true;
    public float gravityMultipler=1;
  

    Vector2 _mouseFirstPos;
    Vector2 _mouseCurrentPos;
    Vector2 _mouseDeltaPos;


    public Alive(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }

    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        GetMouseInput();
      

    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        sm.anim.SetBool("Grounded", sm.isGrounded);
        RaycastHit hit;
        if (Physics.Raycast(sm.gameObject.transform.position, -sm.gameObject.transform.up, out hit, sm.characterStats.groundCheckDistance))
        {
            sm.isGrounded = true;
            gravityMultipler = 1;

            //sm.trailEffect.isTrailActive = false;
        }
        else
        {
            sm.isGrounded = false;
            sm.trailEffect.isTrailActive = true;
        }
    }


    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
       

        //Debug.Log("giriyorum Grounded");

        Gravity();
        
    }


    private void Gravity()
    {
        if (!sm.isGrounded && gravityEnable)
        {
            sm.rb.velocity = new Vector3(sm.rb.velocity.x, -sm.characterStats.fallSpeed*gravityMultipler, sm.rb.velocity.z);
            //sm.rb.MovePosition(new Vector3(sm.gameObject.transform.position.x, sm.gameObject.transform.position.y - 1 * 9.81f * Time.fixedDeltaTime, sm.gameObject.transform.position.z));
            //sm.gameObject.transform.position = new Vector3(sm.gameObject.transform.position.x, sm.gameObject.transform.position.y - 1 * 9.81f*sm.characterStats.fallSpeed * Time.fixedDeltaTime, sm.gameObject.transform.position.z);
        }
    }
    private void GetMouseInput()
    {



        if (Input.GetMouseButtonDown(0))
        {
            _mouseFirstPos = Input.mousePosition;


        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_mouseFirstPos != Vector2.zero)
            {
                _mouseCurrentPos = Input.mousePosition;
                _mouseDeltaPos = CalculateDeltaPosition(_mouseFirstPos, _mouseCurrentPos);
                float deltaX = _mouseDeltaPos.x;
                float deltaY = _mouseDeltaPos.y;
                if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY) && _mouseDeltaPos != Vector2.zero)
                {

                    if (deltaX > 0)
                    {
                        
                        sm.ChangeState(sm.rightDashState);

                    }
                    else
                    {
                       
                        sm.ChangeState(sm.leftDashState);

                    }

                }
                else if (_mouseDeltaPos != Vector2.zero)
                {
                    if (deltaY > 0)
                    {
                       
                        sm.ChangeState(sm.jumpingState);

                    }
                    else
                    {
                        
                        sm.ChangeState(sm.slidingState);
                    }

                }

              
                _mouseDeltaPos = Vector2.zero;
                _mouseFirstPos = Vector2.zero;
                _mouseCurrentPos = Vector2.zero;

            }
        }




    }




    private Vector2 CalculateDeltaPosition(Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 distanceVector;
        distanceVector = secondPos - firstPos;

        return distanceVector;
    }

}
