using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public static BackgroundMovement Instance;
    private GameObject flagObj;
    private int flag = 0;

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private ObjectPooler _objectPool = null;

    private void Start()
    {
        GameObject obj = _objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(8, 0, 24);
        flagObj = obj;
    }
    public void SpawnNewBackground()
    {
        flag = Random.Range(0, 4);

        GameObject obj = _objectPool.GetPooledObject(flag);




        obj.transform.position = new Vector3(8, 0, flagObj.transform.position.z + 15);
        flagObj = obj;





    }




}
