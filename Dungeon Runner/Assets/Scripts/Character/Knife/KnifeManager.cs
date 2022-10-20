using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager :MonoBehaviour
{

    public KnifeData knifeData;


    public delegate void KnifeFunction(GameObject gameObject);
    public KnifeFunction KnifeSkillUpgrade;


    public delegate void KnifeStat(float stat);
    public KnifeStat KnifeStatUpgrade;

    //public SkillScriptable skillData;


    [HideInInspector]
    public float knifeDamage;
    [HideInInspector]
    public float knifeRange;
    private void OnEnable()
    {
        
    }

    private void Start()
    {
        knifeDamage = knifeData.knifeDamage;
        knifeRange = knifeData.knifeLifeTime;
    }
   

}
