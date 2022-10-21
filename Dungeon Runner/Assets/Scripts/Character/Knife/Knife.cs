using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : KnifeManager
{
    
    private Rigidbody _rb;

    [HideInInspector]
    public float damage;

    public ParticleSystem ps;
  

  

    private void OnEnable()
    {
        StartCoroutine(KnifeLifeTime(knifeRange));
       

    }
    private void OnDisable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
        ps.Stop();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")||other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("knife trigger");
            this.gameObject.SetActive(false);
            if (other.gameObject.CompareTag("Enemy"))
            {
                SpawnSideKnife();
            }
            
        }
        if (!other.gameObject.CompareTag("Knife"))
        {
            ps.Play();
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


    private void SpawnSideKnife()
    {
        if (isSideKnifeActive)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject go;
                go=Instantiate(this.gameObject);
                if (i==1)
                {
                    go.transform.rotation = Quaternion.Euler(0, -180, -90);
                    go.GetComponent<Rigidbody>().AddForce(go.transform.up * attackData.throwSpeed);
                }
                else
                {
                    go.transform.rotation = Quaternion.Euler(0, 0, -90);
                    go.GetComponent<Rigidbody>().AddForce(go.transform.up * attackData.throwSpeed);
                }
            }
        }
    }

}
