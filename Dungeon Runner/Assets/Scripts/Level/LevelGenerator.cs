
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator Instance;
    private GameObject flagObj;

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

        for (int i = 0; i < 3; i++)
        {
            SpawnNewTile();
        }



    }

    public void SpawnNewTile()
    {
        flag = Random.Range(0, 5);

        GameObject obj = objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15);
        flagObj = obj;

    }




}


