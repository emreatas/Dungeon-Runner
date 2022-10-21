using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseSkill : MonoBehaviour
{
    public SkillType skillType;
    public SkillTier skillTier;

    public delegate void CurrentSkill();
    public CurrentSkill Cast;

    public delegate void PassiveSkill();
    public PassiveSkill PassiveSkillCast;

    private float _multipler;
    public enum SkillType
    {
        Castable,
        Passive
    }
    public enum SkillTier
    {
        Common,
        Rare,
        Legendary
    }
    private void Awake()
    {
        switch (skillType)
        {
            case SkillType.Castable:
                break;
            case SkillType.Passive:

                break;
            default:
                break;
        }
        switch (skillTier)
        {
            case SkillTier.Common:
                _multipler = 0.25f;
                break;
            case SkillTier.Rare:
                _multipler = 0.5f;
                break;
            case SkillTier.Legendary:
                _multipler = 2f;
                break;
            default:
                break;
        }
    }

    public void IncreaseStat(float stat)
    {
        stat += stat * _multipler;
    }



}
