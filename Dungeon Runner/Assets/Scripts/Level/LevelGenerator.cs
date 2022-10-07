
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
        int counter = 0;

        while (true)
        {
            flag = Random.Range(0, 4);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, counter * 15);
            counter++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }




}


