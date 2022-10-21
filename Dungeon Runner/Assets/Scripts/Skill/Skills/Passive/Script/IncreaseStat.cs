using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStat : BaseSkill
{
   public void IncreaseStats(float firstStat,float increaseAmount)
    {
        firstStat += increaseAmount;
    }
}
