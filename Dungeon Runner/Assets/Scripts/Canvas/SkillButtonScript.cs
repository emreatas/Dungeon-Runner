using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillButtonScript : MonoBehaviour
{

    public enum Skill
    {
        ActivateDoubleKnife,
        IncreaseThrowSpeed,
        IncreaseAttackSpeed,
        IncreaseDamage,
        IncreaseRange,
        IncreaseReloadSpeed,
        ActivateSideKnife

    }


    [SerializeField] private int _cost;
    [SerializeField] private Skill _skill;


    public void BuySkill()
    {
        GameManager.Instance.OnBuySkill(_cost);

        switch (_skill)
        {
            case Skill.ActivateDoubleKnife:
                GameManager.Instance.OnActivateDoubleKnife();
                break;
            case Skill.IncreaseThrowSpeed:
                break;
            case Skill.IncreaseAttackSpeed:
                break;
            case Skill.IncreaseDamage:
                break;
            case Skill.IncreaseRange:
                break;
            case Skill.IncreaseReloadSpeed:
                break;
            case Skill.ActivateSideKnife:
                break;
        }

    }
}