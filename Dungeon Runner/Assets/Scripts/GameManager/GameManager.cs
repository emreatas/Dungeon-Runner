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


    public void OnDashLeft()
    {
        if (DashLeft!=null)
        {
            DashLeft();
        }
    }

    public void OnDashRight()
    {
        if (DashRight!=null)
        {
            DashRight();
        }
    }




    private int currentTile = 0;
    public int GetCurrentTile()
    {
        return currentTile;
    }
    public void SetCurrentTile()
    {
        currentTile++;

    }


}
