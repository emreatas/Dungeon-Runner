
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator Instance;
    private GameObject flagObj;
    private bool obstacleTile = true;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private ObjectPooler objectPool = null;
    int flag = 0;

    private void Start()
    {
        GameObject obj = objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(0, 0, 15);
        flagObj = obj;

        SpawnNonObstacleTile();
        SpawnObstacleTile();


    }

    public void SpawnObstacleTile()
    {
        flag = Random.Range(2, 5);

        GameObject obj = objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + obj.GetComponent<Collider>().bounds.size.z);
        flagObj = obj;

    }

    public void SpawnNonObstacleTile()
    {
        flag = Random.Range(0, 2);

        GameObject obj = objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + obj.GetComponent<Collider>().bounds.size.z);
        flagObj = obj;

    }
}


