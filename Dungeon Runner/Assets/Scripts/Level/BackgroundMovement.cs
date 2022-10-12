using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public static BackgroundMovement Instance;
    private GameObject flagObjRight;
    private GameObject flagObjLeft;
    private int flag = 0;
    [SerializeField] private int _xRightTransform;
    [SerializeField] private int _xLeftTransform;

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private ObjectPooler _objectPool = null;

    private void Start()
    {
        GameObject objRight = _objectPool.GetPooledObject(flag);
        objRight.transform.position = new Vector3(_xRightTransform, 0, 24);
        flagObjRight = objRight;
        GameObject objLeft = _objectPool.GetPooledObject(4);
        objLeft.transform.position = new Vector3(_xLeftTransform, 0, 24);
        flagObjLeft = objLeft;
    }
    public void SpawnRightBackground()
    {
        flag = Random.Range(0, 4);

        GameObject obj = _objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(_xRightTransform, 0, flagObjRight.transform.position.z + 15);
        flagObjRight = obj;





    }


    public void SpawnLeftBackground()
    {
        flag = Random.Range(4, 6);

        GameObject obj = _objectPool.GetPooledObject(flag);
        obj.transform.position = new Vector3(_xLeftTransform, 0, flagObjLeft.transform.position.z + 15);
        flagObjLeft = obj;

    }



}
