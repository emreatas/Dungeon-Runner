using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="AttackStats",menuName = "CharacterStats/AttackStats")]
public class AttackStatsScriptable : ScriptableObject
{
    public float attackSpeed;
    public float reloadSpeed;
}
