using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public KnifeData knifeData;

    private void OnEnable()
    {
        StartCoroutine(KnifeLifeTime(knifeData.knifeLifeTime));
    }
    void Start()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        
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
