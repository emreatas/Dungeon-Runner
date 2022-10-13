using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Vector3 _distance;
    [SerializeField]private Transform _lookAt;
    [SerializeField] private GameObject _followedbyCamObject;
    private Quaternion _targetRotationLeft;
    private Quaternion _targetRotationRight;

    private float _rightPosition;
    private float _leftPosition;
    private float _firstPos;

    [SerializeField] private float _rotationDistance;


    [SerializeField] private float _cameraMovementSpeed;

   



    private void OnEnable()
    {
        GameManager.DashRight += GameManager_DashRight;
        GameManager.DashLeft += GameManager_DashLeft;
    }

    private void GameManager_DashLeft()
    {
       // StartCoroutine(LeftDash());
    }

    private void GameManager_DashRight()
    {
        
        //StartCoroutine(RightDash());

    }

    private void OnDisable()
    {
        GameManager.DashRight -= GameManager_DashRight;
        GameManager.DashLeft -= GameManager_DashLeft;
    }
    void Start()
    {
        _distance = _followedbyCamObject.transform.position - gameObject.transform.position;
        _targetRotationLeft = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y - _rotationDistance, gameObject.transform.rotation.z, 0);
        _targetRotationRight= new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y + _rotationDistance, gameObject.transform.rotation.z, 0);
        _firstPos = gameObject.transform.position.x;
       
    }


    void FixedUpdate()
    {
        
        //gameObject.transform.LookAt(_lookAt);
        Vector3 followPos = (_followedbyCamObject.transform.position - _distance);
        gameObject.transform.position = new Vector3(followPos.x, followPos.y, gameObject.transform.position.z);
        
       

    }


  
    IEnumerator LeftDash()
    {
        yield return new WaitForFixedUpdate();
        if (gameObject.transform.rotation.y != _targetRotationLeft.y)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,_targetRotationLeft , _cameraMovementSpeed * Time.fixedDeltaTime);
            StartCoroutine(LeftDash());
        }
        else
        {
            StopCoroutine(LeftDash());
        }
    }


    IEnumerator RightDash()
    {
        yield return new WaitForFixedUpdate();
        if (gameObject.transform.rotation.y != _targetRotationRight.y)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, _targetRotationRight, _cameraMovementSpeed * Time.fixedDeltaTime);
            StartCoroutine(RightDash());
        }
        else
        {
            StopCoroutine(RightDash());
        }
    }



}
