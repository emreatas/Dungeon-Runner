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
        if (isEnemyDetected)
        {
            AnimationPlay();
            anim.SetBool("FireStart", true);
            if (!alreadyAttacked)
            {
                Vector3 fireRota = GameObject.Find("Barrel").transform.position - target.transform.position;
                Rigidbody rb = Instantiate(alienStats.fireTile, GameObject.Find("Barrel").transform.position, Quaternion.LookRotation(fireRota)).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 100f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), alienStats.timeBetweenAttacks);
            }
        }
        else
        {
            AnimationStop();
            anim.SetBool("FireStart", false);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    void AnimationPlay()
    {
        Vector3 laserRota = target.transform.position - GameObject.Find("Barrel").transform.position + new Vector3(1f,1f,1f);
        //Quaternion laserRotation = Quaternion.LookRotation(laserRota);
        //Vector3 _laserRota = laserRotation.eulerAngles;
        if (!GameObject.FindGameObjectWithTag("RifleBullet"))
        {
            ParticleSystem _laser = Instantiate(laser, GameObject.Find("Barrel").transform.position, Quaternion.LookRotation(laserRota));
            _laser.transform.parent = transform;
            _laser.Play();
        }
        else if (GameObject.FindGameObjectWithTag("RifleBullet").transform.position != transform.position)
        {
            Quaternion laserRotation = Quaternion.LookRotation(laserRota);
            Vector3 _laserRota = laserRotation.eulerAngles;
            GameObject.FindGameObjectWithTag("RifleBullet").transform.rotation = Quaternion.Euler(_laserRota);
            //GameObject.FindGameObjectWithTag("Laser").transform.position = transform.position;
        }
    }
    void AnimationStop()
    {
        if (GameObject.FindGameObjectWithTag("RifleBullet"))
        {
            Destroy(GameObject.FindGameObjectWithTag("RifleBullet"));
        }
    }
}