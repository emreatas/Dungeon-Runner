using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private Transform target;
    public EnemyScriptable enemyStats;
    private bool isEnemyDetected;
    bool alreadyAttacked;
    public ParticleSystem laser;
    void Update()
    {
        FindPlayer();
        if (target == null)
        {
            return;
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rota = lookRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rota.y, 0f);
        }
        Fire();
    }
    void FindPlayer()
    {
        if (GameObject.FindGameObjectWithTag(enemyStats.playerTag))
        {
            GameObject player = GameObject.FindGameObjectWithTag(enemyStats.playerTag);
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= enemyStats.range)
            {
                target = player.transform;
                if(distanceToPlayer <= enemyStats.sightRange)
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
        if (isEnemyDetected)
        {
            AnimationPlay();
            if (!alreadyAttacked)
            {
                Vector3 fireRota = GameObject.Find("FirePos").transform.position - target.transform.position;
                Rigidbody rb = Instantiate(enemyStats.fireTile, GameObject.Find("FirePos").transform.position, Quaternion.LookRotation(fireRota)).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 100f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), enemyStats.timeBetweenAttacks);
            }
        }
        else
        {
            AnimationStop();
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    void AnimationPlay()
    {
        Vector3 laserRota = target.transform.position - GameObject.Find("FirePos").transform.position + new Vector3(1f,1f,1f);
        //Quaternion laserRotation = Quaternion.LookRotation(laserRota);
        //Vector3 _laserRota = laserRotation.eulerAngles;
        if (!GameObject.FindGameObjectWithTag("Laser"))
        {
            ParticleSystem _laser = Instantiate(laser, GameObject.Find("FirePos").transform.position, Quaternion.LookRotation(laserRota));
            _laser.transform.parent = transform;
            _laser.Play();
        }
        else if (GameObject.FindGameObjectWithTag("Laser").transform.position != transform.position)
        {
            Quaternion laserRotation = Quaternion.LookRotation(laserRota);
            Vector3 _laserRota = laserRotation.eulerAngles;
            GameObject.FindGameObjectWithTag("Laser").transform.rotation = Quaternion.Euler(_laserRota);
            //GameObject.FindGameObjectWithTag("Laser").transform.position = transform.position;
        }
    }
    void AnimationStop()
    {
        if (GameObject.FindGameObjectWithTag("Laser"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Laser"));
        }
    }
}