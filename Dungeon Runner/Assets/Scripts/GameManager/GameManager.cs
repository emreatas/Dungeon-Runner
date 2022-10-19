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
    public static event Action<int> BuySkill;

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
            SetCurrency(1);
        }
    }

    public void OnBuySkill(int cost)
    {
        if (BuySkill != null)
        {
            BuySkill(cost);
            SetCurrency(-cost);
        }
    }
    #endregion

    #region Currency

    private int currentCurrency = 0;
    public int GetCurrency()
    {
        return currentCurrency;
    }
    public void SetCurrency(int cost)
    {
        currentCurrency += cost;

    }

    #endregion

}
