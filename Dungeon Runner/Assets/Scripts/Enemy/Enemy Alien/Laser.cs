using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _line;
    public Transform barrel;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                _line.enabled = true;
                _line.SetPosition(0, barrel.position);
                _line.SetPosition(1, hit.point);
            }
        }
        else
        {
            _line.enabled = false;
        }

    }
}
