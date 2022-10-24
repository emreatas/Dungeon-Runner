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
    private float fireCountDown = 0f;
    private int wave;
    private bool isDied = false;
    private float targetWeight = 0f;

    [SerializeField]
    private ObjectPooler bulletPool;

    [SerializeField]
    private ParticleSystem bloodPs;

    private int _health;








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
                fireCountDown = 1f / alienStats.fireRate;
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
                aimTarget.position = player.GetComponent<CharacterHealth>().lookAt.position;
                if (distanceToPlayer <= alienStats.sightRange)
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
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = barrel.position;
        obj.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * obj.GetComponent<AlienBullet>().GetBulletSpeed());
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            Debug.Log("Vurduk");
            _health -= (int)collision.GetComponent<Knife>().damage;
            bloodPs.Play();
            if (_health <= 0)
            {
                isDied = true;
                anim.SetBool("Die", true);
                targetWeight = 0f;
                gameObject.GetComponent<Collider>().enabled = false;
                GameManager.Instance.OnCollectItem();
            }
        }

    }
    void OnEnable()
    {


        GameManager.LevelWave += GameManager_LevelWave;
        GameManager.Dead += GameManager_Dead;
        isDied = false;
        anim.SetBool("Die", false);
        gameObject.GetComponent<Collider>().enabled = true;
        alienStats.health = 20 + wave * 20;
        _health = alienStats.health;
    }

    private void GameManager_Dead()
    {
        inFireDistance = false;
    }

    private void GameManager_LevelWave(int obj)
    {
        wave = obj;
    }
    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;
        GameManager.LevelWave -= GameManager_LevelWave;
    }
}