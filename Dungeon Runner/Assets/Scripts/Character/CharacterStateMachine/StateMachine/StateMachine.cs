using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
     BaseState currentState;

    private void OnEnable()
    {
        GameManager.Dead += GameManager_Dead;
    }
    private void GameManager_Dead()
    {
        if (currentState!=null)
        {
            Debug.Log("CALL DEAD");
            currentState.Dead();
        }
    }

    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;
    }

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    private void FixedUpdate()
    {
        if (currentState!=null)
        {
            currentState.FixedUpdatePhysics();
        }
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

  

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }

}
