using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour,IDamageable
{
    public Transform lookAt;
    public CharacterHealthStats characterHealthData;
    [HideInInspector]
    public float characterCurrentHealth;


    private void Start()
    {
        characterCurrentHealth = characterHealthData.characterBaseHealth;
    }

    public void TakeDamege()
    {
        
    }
}
