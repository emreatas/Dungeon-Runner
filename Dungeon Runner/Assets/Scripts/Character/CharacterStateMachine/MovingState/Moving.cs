using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{

    protected MovementSM sm;

    public enum JumpType
    {
        LeftJump,
        RightJump
    }
    public JumpType jumpType;

    Vector2 _mouseFirstPos ;
    Vector2 _mouseCurrentPos ;
    Vector2 _mouseDeltaPos ;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {
        sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        /* if (Mathf.Abs(sm.rb.velocity.magnitude) < Mathf.Epsilon)
         {
             stateMachine.ChangeState(sm.idleState);
         }*/
        GetMouseInput();
       
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        MoveCharacter();

    }




    private void MoveCharacter()
    {
       // sm.rb.MovePosition(new Vector3(sm.gameObject.transform.position.x, sm.gameObject.transform.position.y, sm.gameObject.transform.position.z + 1 *sm.characterStats.verticalMovementSpeed * Time.fixedDeltaTime));
    }
    private void GetMouseInput()
    {
      


        if (Input.GetMouseButtonDown(0))
        {
            _mouseFirstPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _mouseCurrentPos = Input.mousePosition;
            _mouseDeltaPos = CalculateDeltaPosition(_mouseFirstPos, _mouseCurrentPos);

            float deltaX = _mouseDeltaPos.x;
            

            if ( _mouseDeltaPos != Vector2.zero)
            {
                if (deltaX > 0)
                {
                    jumpType = JumpType.RightJump;
                }
                else
                {
                    jumpType = JumpType.LeftJump;
                }
            }

            Debug.Log(jumpType);



        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_mouseDeltaPos != Vector2.zero)
            {
               
                _mouseDeltaPos = Vector2.zero;
                _mouseFirstPos = Vector2.zero;
                _mouseCurrentPos = Vector2.zero;
                sm.ChangeState(sm.jumpingState);
                //_state = Enums.BallState.Moving;
                //_movementBehaviour = Enums.BallMovementBehaviour.Idle;
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
