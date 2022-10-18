using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterStat",menuName ="CharacterStats/MovementStats")]
public class CharacterStatsScriptable : ScriptableObject
{
    [Header("Movement")]
    public float verticalMovementSpeed;
    
    [Header("Jump/Dash")]
    public float horizontalJumpSpeed;

    public float horizontalJumpRange;

    public float verticalJumpRange;

    public float verticalJumpSpeed;

    public float groundCheckDistance;

    [Header("Gravity")]
    public float fallSpeed;

    [Header("Sliding")]

    public float slidingTime;


    [Header("Conrol")]
    public float inputSensitivity;


   
       
}
