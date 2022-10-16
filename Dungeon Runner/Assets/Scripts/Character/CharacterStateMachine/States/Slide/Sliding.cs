using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : Grounded
{

    private Vector3 _colliderFirstCenterPos;
    private float _colliderFirstHeight;


    private float _timer;

   
    public Sliding(MovementSM stateMachine) : base("Sliding", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        _timer = sm.characterStats.slidingTime;
        _colliderFirstCenterPos = sm.characterCollider.center;
        _colliderFirstHeight = sm.characterCollider.height;
        sm.anim.SetBool("Sliding", true);
        //sm.StartCoroutine(SlideToMove());
        sm.trailEffect.isTrailActive = true;
        gravityMultipler = 5;
        sm.characterCollider.height = 0.5f;
        sm.characterCollider.center = new Vector3(sm.characterCollider.center.x, 0.2f, sm.characterCollider.center.z);
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
       
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
      
    }
    public override void FixedUpdatePhysics()
    {
        base.FixedUpdatePhysics();
        if (_timer > 0)
        {
            _timer -= Time.fixedDeltaTime;

        }
        else
        {

            sm.ChangeState(sm.idleState);


        }
    }

    public override void Exit()
    {
        base.Exit();
        //sm.StopCoroutine(SlideToMove());
        sm.anim.SetBool("Sliding", false);
        sm.characterCollider.height = _colliderFirstHeight;
        sm.characterCollider.center = _colliderFirstCenterPos;
       
    }
    //Bunun yerine dash gibi slide range koyup kontrol ettir
    IEnumerator SlideToMove()
    {
        
        yield return new WaitForSeconds(sm.characterStats.slidingTime);
        
        
        
        

    }
}
