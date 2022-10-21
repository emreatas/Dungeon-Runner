using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAlien : MonoBehaviour
{
    public EnemyScriptable alienStats;
    public Animator anim;
    public Transform barrel;
    public static bool inFireDistance = false;
    public Transform aimTarget;
    public Rig rig;

    private Transform target;
    private float fireRate = 2f;
    private float fireCountDown = 0f;
    private int wave;
    private bool isDied = false;
    private float targetWeight = 0f;

    [SerializeField]
    private ObjectPooler bulletPool;
    void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);
        FindPlayer();
        if (target == null)
        {
            targetWeight = 0f;
        }
        else
        {
            targetWeight = 1f;
            if (fireCountDown <= 0f && inFireDistance && !isDied)
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
                aimTarget.position = player.GetComponent<CharacterHealth>().lookAt.position;
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
                isDied = true;
                anim.SetBool("Die", true);
            }
        }
    }
    void OnEnable()
    {
        GameManager.LevelWave += GameManager_LevelWave;
        isDied = false;
        anim.SetBool("Die", false);
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