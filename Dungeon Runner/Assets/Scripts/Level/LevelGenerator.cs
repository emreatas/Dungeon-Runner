using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour, IPooledObject
{

    ObjectPooler pooler;

    ObjectPool<GameObject> _pool;

    public void OnObjectSpawn()
    {

    }


}
