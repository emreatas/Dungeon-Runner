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
        GameManager.Dead += GameManager_Dead;
    }

    private void GameManager_Dead()
    {
        characterCurrentHealth = 0;
        GameManager.Instance.OnCharacterHealthChange(characterCurrentHealth);

    }

    private void GameManager_LevelWave(int obj)
    {

        characterCurrentHealth += (obj + 1) * 10;
        if (characterCurrentHealth > 100)
        {
            characterCurrentHealth = 100;
        }
        Debug.Log("girdim");


        GameManager.Instance.OnCharacterHealthChange(characterCurrentHealth);
    }

    private void OnDisable()
    {
        GameManager.LevelWave -= GameManager_LevelWave;
        GameManager.Dead -= GameManager_Dead;
    }
    private void Start()
    {

        characterCurrentHealth = characterHealthData.characterBaseHealth;

        GameManager.Instance.OnCharacterHealthChange(characterCurrentHealth);
    }

    public void TakeDamege(float damage)
    {
        characterCurrentHealth -= damage;
    }
    private void Update()
    {
        Debug.Log(characterCurrentHealth);
    }

}
