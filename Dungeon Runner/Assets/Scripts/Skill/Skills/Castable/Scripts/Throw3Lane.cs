using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw3Lane : BaseSkill
{
   public void Cast(GameObject gO)
   {
        List<GameObject> spawnedKnifes=new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            Instantiate(gO);
            spawnedKnifes.Add(gO);
        }
        spawnedKnifes[0].transform.rotation = Quaternion.Euler(0, 0, -90);
        spawnedKnifes[1].transform.rotation = Quaternion.Euler(0, -180, -90);

        spawnedKnifes[0].GetComponent<Rigidbody>().AddForce(spawnedKnifes[0].transform.forward * 100f);
        spawnedKnifes[1].GetComponent<Rigidbody>().AddForce(spawnedKnifes[1].transform.forward * 100f);
    }
  
   
}
