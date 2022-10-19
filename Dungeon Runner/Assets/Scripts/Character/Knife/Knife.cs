using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public KnifeData knifeData;
    private Rigidbody _rb;

    private void OnEnable()
    {
        StartCoroutine(KnifeLifeTime(knifeData.knifeLifeTime));
        knifeData.Asd();
        
    }
    private void OnDisable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
    }
    void Start()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")||other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);

        }
        
        
    }


    IEnumerator KnifeLifeTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        if (gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
            
            

        
        

    }

}
