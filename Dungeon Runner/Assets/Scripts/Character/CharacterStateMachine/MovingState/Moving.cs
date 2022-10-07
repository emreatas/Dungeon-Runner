using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{

    protected MovementSM sm;

    public enum JumpType
    {
        LeftJump,
        RightJump,
        UpJump
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
        GetMouseInput();
       
    }

   

    //Add upJump State and mouse input control!!
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
            float deltaY = _mouseDeltaPos.y;


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
            else if (_mouseDeltaPos != Vector2.zero)
            {
                if (deltaY > 0)
                {
                    jumpType = JumpType.UpJump;
                }
                else
                {
                    //Add slideState
                    //_movementBehaviour = Enums.BallMovementBehaviour.SwipedDown;
                }
            }

            Debug.Log(jumpType);



        }
        if (Input.GetMouseButtonUp(0))
        {
            
               
                _mouseDeltaPos = Vector2.zero;
                _mouseFirstPos = Vector2.zero;
                _mouseCurrentPos = Vector2.zero;
                sm.ChangeState(sm.jumpingState);
               
            

        }
    }
    private Vector2 CalculateDeltaPosition(Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 distanceVector;
        distanceVector = secondPos - firstPos;

        return distanceVector;
    }
}
