using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    private int wave;
    private float bulletSpeed;
    private int bulletDamage;
    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
    public int GetBulletDamage()
    {
        return bulletDamage;
    }
    void OnEnable()
    {
        GameManager.LevelWave += GameManager_LevelWave;
        bulletSpeed = 500f + wave * 100f;
        bulletDamage = (wave + 1) * 5;
    }

    void GameManager_LevelWave(int obj)
    {
        wave = obj;
    }
    void OnDisable()
    {
        GameManager.LevelWave += GameManager_LevelWave;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            gameObject.SetActive(false);
        }
       
       
        
    }
}
