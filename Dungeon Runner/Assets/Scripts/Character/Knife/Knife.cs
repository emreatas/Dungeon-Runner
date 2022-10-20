using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : KnifeManager
{
    
    private Rigidbody _rb;

    [HideInInspector]
    public float damage;
    private float _range;

  

    private void OnEnable()
    {
        StartCoroutine(KnifeLifeTime(knifeData.knifeLifeTime));


    }
    private void OnDisable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")||other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("knife trigger");
            this.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("Enemy"))
            {
                
            }

        }
        
        
    }


    IEnumerator KnifeLifeTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        if (gameObject.activeSelf)
        {
            //KnifeSkillFunction();
            this.gameObject.SetActive(false);
        }
            
            

        
        

    }

}
