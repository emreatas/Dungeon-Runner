using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager :MonoBehaviour
{

    public KnifeData knifeData;


    [HideInInspector]
    public float knifeDamage;
    [HideInInspector]
    public float knifeRange;

    private void Awake()
    {
        knifeDamage = knifeData.knifeDamage;
        knifeRange = knifeData.knifeLifeTime;
      
       
    }
  
   

}
