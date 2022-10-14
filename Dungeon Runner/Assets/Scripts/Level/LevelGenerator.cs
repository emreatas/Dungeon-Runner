
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator Instance;
    private GameObject flagObj;
    [SerializeField] private int spawnedTile = 0;
    [SerializeField] private int wave = 0;
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


        if (spawnedTile == wave * 20 + 20)
        {

            GameObject marketTile = objectPool.GetPooledObject(5);
            marketTile.transform.position = new Vector3(0, 0, flagObj.transform.position.z + marketTile.GetComponent<Collider>().bounds.size.z - 0.1f);
            flagObj = marketTile;
            wave++;
            spawnedTile = 0;

        }
        else
        {
            flag = Random.Range(2, 5);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + obj.GetComponent<Collider>().bounds.size.z - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }

    }

    public void SpawnNonObstacleTile()
    {


        if (spawnedTile == wave * 20 + 20)
        {

            GameObject marketTile = objectPool.GetPooledObject(5);
            marketTile.transform.position = new Vector3(0, 0, flagObj.transform.position.z + marketTile.GetComponent<Collider>().bounds.size.z - 0.1f);
            flagObj = marketTile;
            wave++;
            spawnedTile = 0;

        }
        else
        {
            flag = Random.Range(0, 2);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + obj.GetComponent<Collider>().bounds.size.z - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }

    }
}


