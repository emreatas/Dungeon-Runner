using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="SkillData",menuName ="SkillData/SkillData")]
public class SkillScriptable : ScriptableObject
{
    public List<UsableSkills> allSkills;


}
[System.Serializable]
public class UsableSkills
{
    public SkillType skillType;
    public enum SkillType
    {
        StatIncrease,
        Castable
    }

    public BaseSkill skill;
}


