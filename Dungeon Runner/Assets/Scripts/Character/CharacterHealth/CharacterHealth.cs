using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{
    public Transform lookAt;
    public CharacterHealthStats characterHealthData;
    [HideInInspector]
    public float characterCurrentHealth;
    private void OnEnable()
    {
        GameManager.LevelWave += GameManager_LevelWave;
    }

    private void GameManager_LevelWave(int obj)
    {
        characterCurrentHealth += (obj + 1) * 10;
    }

    private void OnDisable()
    {
        GameManager.LevelWave -= GameManager_LevelWave;
    }
    private void Start()
    {
        characterCurrentHealth = characterHealthData.characterBaseHealth;
    }

    public void TakeDamege(float damage)
    {
        characterCurrentHealth -= damage;
    }


}
