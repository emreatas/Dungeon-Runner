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
    public static event Action MarketTile;
    public static event Action<int> LevelWave;



    public static event Action<float> CharacterHealthChange;

    #region Skill Events
    public static event Action ActivateDoubleKnife;
    public static event Action IncreaseThrowSpeed;
    public static event Action IncreaseAttackSpeed;
    public static event Action IncreaseReloadSpeed;

    public static event Action IncreaseDamage;
    public static event Action IncreaseRange;

    public static event Action ActivateSideKnife;
    public static event Action ActivateShield;
    #endregion



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

    #region Level Wave

    public void OnLevelWave(int wave)
    {
        if (LevelWave != null)
        {
            LevelWave(wave);
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

    public void OnMarketTile()
    {
        if (MarketTile != null)
        {
            MarketTile();
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

    #region Skill Event Functions
    public void OnActivateDoubleKnife()
    {
        if (ActivateDoubleKnife!=null)
        {
            ActivateDoubleKnife();
        }
    }
    public void OnIncreaseThrowSpeed()
    {
        if (IncreaseThrowSpeed!=null)
        {
            IncreaseThrowSpeed();
        }
    }
    
    public void OnIncreaseAttackSpeed()
    {
        if (IncreaseAttackSpeed!=null)
        {
            IncreaseAttackSpeed();
        }
    }

    public void OnIncreaseDamage()
    {
        if (IncreaseDamage!=null)
        {
            IncreaseDamage();
        }
    }

    public void OnIncreaseRange()
    {
        if (IncreaseRange!=null)
        {
            IncreaseRange();
        }
    }

    public void OnIncreaseReloadSpeed()
    {
        if (IncreaseReloadSpeed!=null)
        {
            IncreaseReloadSpeed();
        }
    }

    public void OnActivateSideKnife()
    {
        if (ActivateSideKnife!=null)
        {
            ActivateSideKnife();
        }
    }
    public void OnActivateShield()
    {
        if (ActivateShield!=null)
        {
            ActivateShield();
        }
    }
    #endregion

    public void OnCharacterHealthChange(float currentHealth)
    {
        if (CharacterHealthChange!=null)
        {
            CharacterHealthChange(currentHealth);
        }
    }

}
