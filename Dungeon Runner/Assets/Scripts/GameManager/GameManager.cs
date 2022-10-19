using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public static event Action DashLeft;
    public static event Action DashRight;

    public static event Action Dead;

    public static event Action<bool> GamePause;
    public static event Action CollectItem;

    #region Movement Events
    public void OnDashLeft()
    {
        if (DashLeft != null)
        {
            DashLeft();
        }
    }

    public void OnDashRight()
    {
        if (DashRight != null)
        {
            DashRight();
        }
    }
    #endregion


    #region Control Events
    public void OnDead()
    {
        if (Dead != null)
        {
            Dead();
        }
    }




    #endregion


    #region UI Events
    public void OnGamePause(bool isPaused)
    {
        if (GamePause != null)
        {
            GamePause(isPaused);
        }
    }

    public void OnCollectItem()
    {
        if (CollectItem != null)
        {
            CollectItem();
        }
    }
    #endregion


    private int currentTile = 0;
    public int GetCurrentTile()
    {
        return currentTile;
    }
    public void SetCurrentTile(int spawnedTile)
    {
        currentTile = spawnedTile;

    }


}
