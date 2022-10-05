using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    private Vector3 distance;
    [SerializeField] private GameObject _followedbyCamObject;
    void Start()
    {
        distance = _followedbyCamObject.transform.position - gameObject.transform.position;
    }

    
    void FixedUpdate()
    {
        gameObject.transform.position = (_followedbyCamObject.transform.position - distance );
    }
}
