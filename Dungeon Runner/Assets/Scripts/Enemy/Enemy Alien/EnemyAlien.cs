using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlien : MonoBehaviour
{

    public EnemyScriptable alienStats;
    public Animator anim;
    public Transform barrel;
    public static bool inFireDistance = false;

    private Transform target;
    private float fireRate = 2f;
    private float fireCountDown = 0f;
    private int wave;

    [SerializeField]
    private ObjectPooler bulletPool;

    private void Start()
    {
                
    }
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
            if (fireCountDown <= 0f && inFireDistance)
            {
                Fire();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
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
                    inFireDistance = true;
                }
                else
                {
                    inFireDistance = false;
                }
            }
            else
            {
                target = null;
                inFireDistance = false;
            }
        }
    }
    void Fire()
    {
        GameObject obj = bulletPool.GetPooledObject(0);
        if(!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = barrel.position;
        obj.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * 1000f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Knife")
        {
            alienStats.health -= 5;
            if(alienStats.health <= 0)
            {
                
            }
        }
    }
    void OnEnable()
    {
        GameManager.LevelWave += GameManager_LevelWave;
        alienStats.health = wave * 10;
    }

    private void GameManager_LevelWave(int obj)
    {
        wave = obj;
    }
    private void OnDisable()
    {
        GameManager.LevelWave -= GameManager_LevelWave;
    }
}