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
    private float _attackSpeed;


    [Header("Object Pooler")]
    public ObjectPooler objectPooler;
    public Transform knifeSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

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

            iK.weight = Mathf.MoveTowards(iK.weight, 1f, attackStats.attackSpeed * Time.deltaTime);

            if (iK.weight == 1f)
            {
                _reached = true;
                knife.SetActive(false);
                GameObject go;
                go = objectPooler.GetPooledObject(0);
                go.transform.position = knifeSpawnPos.position;
                go.GetComponent<Rigidbody>().AddForce(go.transform.up * attackStats.throwSpeed*100f);
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

            iK.weight = Mathf.MoveTowards(iK.weight, 0f, attackStats.reloadSpeed * Time.deltaTime);



            if (iK.weight == 0f)
            {
                _reached = false;
                knife.SetActive(true);
                _isAttacking = false;
            }
            StartCoroutine(ReloadKnife());
        }
    }


    public void ThrowKnifeX()
    {


    }
}



