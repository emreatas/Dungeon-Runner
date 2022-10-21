using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager :MonoBehaviour
{

    public KnifeData knifeData;
    public AttackStatsScriptable attackData;


    [HideInInspector]
    public bool isSideKnifeActive=false;

    [HideInInspector]
    public float knifeDamage;
    [HideInInspector]
    public float knifeRange;
    private void OnEnable()
    {
        GameManager.IncreaseDamage += GameManager_IncreaseDamage;
        GameManager.IncreaseRange += GameManager_IncreaseRange;
        GameManager.ActivateSideKnife += GameManager_ActivateSideKnife;
    }

    private void GameManager_ActivateSideKnife()
    {
        isSideKnifeActive = true;
    }

    private void GameManager_IncreaseRange()
    {
        knifeRange += knifeRange * 2f;
    }

    private void GameManager_IncreaseDamage()
    {
        knifeDamage += knifeDamage * 2f;
    }
    private void OnDisable()
    {
        GameManager.IncreaseDamage -= GameManager_IncreaseDamage;
        GameManager.IncreaseRange -= GameManager_IncreaseRange;
        GameManager.ActivateSideKnife -= GameManager_ActivateSideKnife;
    }

    private void Awake()
    {
        knifeDamage = knifeData.knifeDamage;
        knifeRange = knifeData.knifeLifeTime;
       
      
       
    }
   



}
