using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlien : MonoBehaviour
{
    private Transform target;
    public EnemyScriptable alienStats;
    private bool isEnemyDetected;
    bool alreadyAttacked;
    public ParticleSystem laser;
    public Animator anim;
    public Transform barrel;
   
    void Update()
    {
        if (target == null)
        {
            Debug.Log("target null");
            anim.SetBool("FireStart", false);
            barrel.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("target not null");
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rota = lookRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rota.y, 0f);
            barrel.GetChild(0).gameObject.SetActive(true);
            anim.SetBool("FireStart", true);
        }
        FindPlayer();
    }
    void FindPlayer()
    {
        if (GameObject.FindGameObjectWithTag(alienStats.playerTag))
        {
            GameObject player = GameObject.FindGameObjectWithTag(alienStats.playerTag);
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= alienStats.range)
            {
                target = player.transform;
                if(distanceToPlayer <= alienStats.sightRange)
                {
                    isEnemyDetected = true;
                }
                else
                {
                    isEnemyDetected = false;
                }
                
            }
            else
            {
                target = null;
                isEnemyDetected = false;
            }
        }
    }
    void Fire()
    {
        
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}