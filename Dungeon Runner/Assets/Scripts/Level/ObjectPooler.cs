using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {

        public Queue<GameObject> _pooledObject;
        public GameObject _objectPrefab;
        public int _poolSize;

    }



    [SerializeField] private Pool[] _pools = null;


    private void Awake()
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i]._pooledObject = new Queue<GameObject>();

            for (int j = 0; j < _pools[i]._poolSize; j++)
            {
                GameObject obj = Instantiate(_pools[i]._objectPrefab);
                obj.SetActive(false);

                _pools[i]._pooledObject.Enqueue(obj);
            }
        }


    }


    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= _pools.Length)
        {
            return null;
        }

        GameObject obj = _pools[objectType]._pooledObject.Dequeue();
        obj.SetActive(true);
        _pools[objectType]._pooledObject.Enqueue(obj);
        return obj;
    }
}
