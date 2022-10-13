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

    [SerializeField] private float _rotationDistance;


    [SerializeField] private float _cameraMovementSpeed;

   



    private void OnEnable()
    {
        GameManager.DashRight += GameManager_DashRight;
        GameManager.DashLeft += GameManager_DashLeft;
    }

    private void GameManager_DashLeft()
    {
        Debug.Log("leftDash");
        LeftDash();
    }

    private void GameManager_DashRight()
    {
        RightDash();

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
       
    }


    void FixedUpdate()
    {
        Vector3 followPos = (_followedbyCamObject.transform.position - _distance);
        gameObject.transform.position = new Vector3(followPos.x, followPos.y, gameObject.transform.position.z);
       

    }


    private void LeftDash()
    {
        //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, new Quaternion(gameObject.transform.rotation.x - _rotationDistance, gameObject.transform.rotation.y, gameObject.transform.rotation.z,1), _cameraMovementSpeed * Time.fixedDeltaTime);
        
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, new Quaternion(gameObject.transform.rotation.x - _rotationDistance, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1), _cameraMovementSpeed * Time.fixedDeltaTime);
        
    }

    private void RightDash()
    {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, new Quaternion(gameObject.transform.rotation.x + _rotationDistance, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1), _cameraMovementSpeed * Time.fixedDeltaTime);
        
       
    }



}
