
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private ObjectPooler objectPool = null;
    int flag = 0;

    private void Start()
    {

        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {


        while (true)
        {
            flag = Random.Range(0, 4);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, 15);

            yield return new WaitForSeconds(spawnInterval);
        }
    }




}


