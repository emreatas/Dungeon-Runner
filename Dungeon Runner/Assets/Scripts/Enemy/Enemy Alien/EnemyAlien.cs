using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlien : MonoBehaviour
{
    private Transform target;
    public EnemyScriptable alienStats;
    private bool isEnemyDetected;
    bool alreadyAttacked;
    public Animator anim;
    void Update()
    {
        FindPlayer();
        if (target == null)
        {
            anim.SetBool("FireStart", false);
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rota = lookRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rota.y + 3f, 0f);
            anim.SetBool("FireStart", true);
        }
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