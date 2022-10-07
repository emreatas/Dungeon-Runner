using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterStat",menuName ="CharacterStats/MovementStats")]
public class CharacterStatsScriptable : ScriptableObject
{
    public float verticalMovementSpeed;
    public float horizontalMovementSpeed;

    public float horizontalJumpSpeed;
}
