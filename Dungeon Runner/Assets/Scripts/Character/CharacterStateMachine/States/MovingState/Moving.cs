using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Grounded
{
    public enum JumpType
    {
        Base,
        LeftJump,
        RightJump,
        UpJump

    }
    public JumpType jumpType;

    Vector2 _mouseFirstPos;
    Vector2 _mouseCurrentPos;
    Vector2 _mouseDeltaPos;
    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {
        
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


    public override void Exit()
    {
        Debug.Log("girdim exit");
        _mouseDeltaPos = Vector2.zero;
        _mouseFirstPos = Vector2.zero;
        _mouseCurrentPos = Vector2.zero;
        base.Exit();
      

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
            float deltaY = _mouseDeltaPos.y;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY) && _mouseDeltaPos != Vector2.zero)
            {
               
                    if (deltaX > 0)
                    {
                        jumpType = JumpType.RightJump;
                        

                    }
                    else
                    {
                        jumpType = JumpType.LeftJump;
                        
                    }

                Debug.Log(jumpType);
                
                sm.ChangeState(sm.dashState);

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

        }
        

    }

    


    private Vector2 CalculateDeltaPosition(Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 distanceVector;
        distanceVector = secondPos - firstPos;

        return distanceVector;
    }


}
