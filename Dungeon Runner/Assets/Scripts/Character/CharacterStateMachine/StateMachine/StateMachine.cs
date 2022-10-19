using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
     BaseState currentState;

    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool isGamePaused;

    private void OnEnable()
    {
        GameManager.Dead += GameManager_Dead;
        GameManager.GamePause += GameManager_GamePause;
    }

    private void GameManager_GamePause(bool obj)
    {
        if (currentState!=null)
        {
            isGamePaused = obj;
        }
    }

    private void GameManager_Dead()
    {
        if (currentState!=null)
        {
            Debug.Log("CALL DEAD");
            currentState.Dead();
            isDead = true;
            
        }
    }

    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;
        GameManager.GamePause -= GameManager_GamePause;
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

  
//for debugging
   /* private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }
   */
}
