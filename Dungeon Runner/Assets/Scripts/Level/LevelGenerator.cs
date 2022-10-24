
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
        GameObject obj = objectPool.GetPooledObject(1);
        obj.transform.position = new Vector3(0, 0, 15);
        flagObj = obj;
        GameObject obj2 = objectPool.GetPooledObject(1);
        obj2.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
        flagObj = obj2;
        GameObject ob3 = objectPool.GetPooledObject(1);
        ob3.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
        flagObj = ob3;

        SpawnObstacleTile();

        GameManager.Instance.OnLevelWave(wave);



    }

    public void SpawnObstacleTile()
    {


        if (spawnedTile == wave * 10 + 10)
        {

            GameObject marketTile = objectPool.GetPooledObject(5);
            marketTile.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = marketTile;
            wave++;
            GameManager.Instance.OnLevelWave(wave);

            spawnedTile = 0;

            flag = Random.Range(2, 5);
            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }
        else
        {
            flag = Random.Range(2, 5);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }

    }

    public void SpawnNonObstacleTile()
    {


        if (spawnedTile == wave * 10 + 10)
        {

            GameObject marketTile = objectPool.GetPooledObject(5);
            marketTile.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = marketTile;
            wave++;
            GameManager.Instance.OnLevelWave(wave);

            spawnedTile = 0;

            flag = Random.Range(0, 2);
            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }
        else
        {
            flag = Random.Range(0, 2);

            GameObject obj = objectPool.GetPooledObject(flag);
            obj.transform.position = new Vector3(0, 0, flagObj.transform.position.z + 15 - 0.1f);
            flagObj = obj;
            spawnedTile++;

        }

    }
}


