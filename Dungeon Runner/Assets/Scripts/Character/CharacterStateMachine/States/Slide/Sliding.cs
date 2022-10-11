using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : Grounded
{

    private Vector3 _colliderFirstCenterPos;
   
    public Sliding(MovementSM stateMachine) : base("Sliding", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        _colliderFirstCenterPos = sm.characterCollider.center;
        sm.anim.SetBool("Sliding", true);
        sm.StartCoroutine(SlideToMove());
    }




    IEnumerator SlideToMove()
    {
        sm.characterCollider.height = 0.5f;
        sm.characterCollider.center = new Vector3(sm.characterCollider.center.x,0.2f, sm.characterCollider.center.z);
        yield return new WaitForSeconds(sm.characterStats.slidingTime);
        sm.anim.SetBool("Sliding", false);
        sm.characterCollider.center = _colliderFirstCenterPos;
        sm.ChangeState(sm.movingState);

    }
}
