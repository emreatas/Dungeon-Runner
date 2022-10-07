using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private Transform target;
    public EnemyScriptable enemyStats;
    private bool isEnemyDetected;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject fireTile;
    void Update()
    {
        ChasePlayer();
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
    }
    void ChasePlayer()
    {
        if (GameObject.FindGameObjectWithTag(enemyStats.playerTag))
        {
            GameObject player = GameObject.FindGameObjectWithTag(enemyStats.playerTag);
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= enemyStats.range)
            {
                target = player.transform;
                isEnemyDetected = true;
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
            Rigidbody rb = Instantiate(fireTile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}