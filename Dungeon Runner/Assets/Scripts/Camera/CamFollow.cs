using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Vector3 _distance;
    [SerializeField] private GameObject _followedbyCamObject;
    private Quaternion _firstRotation;

    private float _rightPosition;
    private float _leftPosition;
    private float _firstPos;

    [SerializeField] private float _movementDistance;


    [SerializeField] private float _cameraMovementSpeed;

    private bool _callLeft;



    private void OnEnable()
    {
        GameManager.DashRight += GameManager_DashRight;
        GameManager.DashLeft += GameManager_DashLeft;
    }

    private void GameManager_DashLeft()
    {
        _callLeft = true;
    }

    private void GameManager_DashRight()
    {


    }

    private void OnDisable()
    {
        GameManager.DashRight -= GameManager_DashRight;
        GameManager.DashLeft -= GameManager_DashLeft;
    }
    void Start()
    {
        _distance = _followedbyCamObject.transform.position - gameObject.transform.position;
        _firstRotation = gameObject.transform.rotation;
        _firstPos = gameObject.transform.position.x;
        _rightPosition = gameObject.transform.position.x + _movementDistance;
        _leftPosition = gameObject.transform.position.x - _movementDistance;
    }


    void FixedUpdate()
    {
        Vector3 followPos = (_followedbyCamObject.transform.position - _distance);
        gameObject.transform.position = new Vector3(followPos.x, followPos.y, gameObject.transform.position.z);
        LeftDash(followPos);

    }


    private void LeftDash(Vector3 pos)
    {
        if (_callLeft)
        {
            if (pos.x != pos.x - _movementDistance)
            {
                pos.x = Mathf.MoveTowards(pos.x, pos.x - _movementDistance, _cameraMovementSpeed);
            }
            else
            {
                _callLeft = false;
            }
        }
        
    }

    private void RightDash(Vector3 pos)
    {

    }



}
