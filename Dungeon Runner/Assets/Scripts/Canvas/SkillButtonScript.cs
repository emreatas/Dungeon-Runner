using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
    [SerializeField] private TextMeshProUGUI _costText;


    private void Start()
    {
        _costText.text = "x" + _cost;
    }

    public void BuySkill()
    {
        GameManager.Instance.OnBuySkill(_cost);

        switch (_skill)
        {
            case Skill.ActivateDoubleKnife:
                GameManager.Instance.OnActivateDoubleKnife();
                break;

            case Skill.IncreaseThrowSpeed:
                GameManager.Instance.OnIncreaseThrowSpeed();
                break;

            case Skill.IncreaseAttackSpeed:
                GameManager.Instance.OnIncreaseAttackSpeed();
                break;

            case Skill.IncreaseDamage:
                GameManager.Instance.OnIncreaseDamage();
                break;

            case Skill.IncreaseRange:
                GameManager.Instance.OnIncreaseRange();
                break;

            case Skill.IncreaseReloadSpeed:
                GameManager.Instance.OnIncreaseReloadSpeed();
                break;

            case Skill.ActivateSideKnife:
                GameManager.Instance.OnActivateSideKnife();
                break;
        }

    }
}