using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;



public class CharacterAttack : MonoBehaviour
{
    public TwoBoneIKConstraint iK;
    public AttackStatsScriptable attackStats;
    private bool _reached = false;
    private bool _isAttacking = false;
    public GameObject knife;

    [Header("Stats")]
    private float _attackSpeed;
    private float _reloadSpeed;
    private float _throwSpeed;


    [Header("Object Pooler")]
    public ObjectPooler objectPooler;
    public Transform knifeSpawnPos;


    private int holder=0;
    private int spawnCount = 1;

    private void Awake()
    {
        _attackSpeed = attackStats.attackSpeed;
        _reloadSpeed = attackStats.reloadSpeed;
        _throwSpeed = attackStats.throwSpeed;
    }
    private void OnEnable()
    {
        GameManager.ActivateDoubleKnife += GameManager_ActivateDoubleKnife;
        GameManager.IncreaseAttackSpeed += GameManager_IncreaseAttackSpeed;
        GameManager.IncreaseReloadSpeed += GameManager_IncreaseReloadSpeed;
        GameManager.IncreaseThrowSpeed += GameManager_IncreaseThrowSpeed;
    }

    private void GameManager_IncreaseThrowSpeed()
    {
        _throwSpeed += _throwSpeed * 2f;
    }

    private void GameManager_IncreaseReloadSpeed()
    {
        _reloadSpeed += _reloadSpeed * 2f;
    }

    private void GameManager_IncreaseAttackSpeed()
    {
        _attackSpeed += _attackSpeed * 2f;
    }

    private void GameManager_ActivateDoubleKnife()
    {
        spawnCount++;
    }

    private void OnDisable()
    {
        GameManager.ActivateDoubleKnife -= GameManager_ActivateDoubleKnife;
        GameManager.IncreaseAttackSpeed -= GameManager_IncreaseAttackSpeed;
        GameManager.IncreaseReloadSpeed -= GameManager_IncreaseReloadSpeed;
        GameManager.IncreaseThrowSpeed -= GameManager_IncreaseThrowSpeed;
    }

   
   

   

    public void Attack()
    {
        if (!_isAttacking)
        {
            StartCoroutine(ThrowKnife());
            _isAttacking = true;

        }

    }

    IEnumerator ThrowKnife()
    {
        yield return new WaitForEndOfFrame();

        if (!_reached)
        {

            iK.weight = Mathf.MoveTowards(iK.weight, 1f, _attackSpeed * Time.deltaTime);

            if (iK.weight == 1f)
            {
                _reached = true;
                knife.SetActive(false);
                StartCoroutine(SpawnKnife(spawnCount));




            }
            StartCoroutine(ThrowKnife());

        }
        else
        {
            StopCoroutine(ThrowKnife());
            StartCoroutine(ReloadKnife());
        }


    }

    IEnumerator ReloadKnife()
    {
        yield return new WaitForEndOfFrame();

        if (_reached)
        {

            iK.weight = Mathf.MoveTowards(iK.weight, 0f, _reloadSpeed * Time.deltaTime);



            if (iK.weight == 0f)
            {
                _reached = false;
                knife.SetActive(true);
                _isAttacking = false;
            }
            StartCoroutine(ReloadKnife());
        }
    }


    IEnumerator SpawnKnife(int spawnCount)
    {
        if (holder!=spawnCount)
        {
            GameObject go;
            go = objectPooler.GetPooledObject(0);
            go.transform.position = knifeSpawnPos.position;
            go.GetComponent<Rigidbody>().AddForce(go.transform.up * _throwSpeed * 100f);
            holder++;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(SpawnKnife(spawnCount));
            
        }
        else
        {
            StopCoroutine(SpawnKnife(spawnCount));
            holder = 0;
        }
        



    }
}



