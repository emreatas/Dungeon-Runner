using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptable _characterStats;



    private Vector3 _mouseFirstPos;
    private Vector3 _mouseCurrentPos;
    private Vector3 _deltaPos;

    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
        
    }
    private void Update()
    {
        SetMovementInputs();
        Debug.Log( _deltaPos.normalized.x );
    }



    private void MoveCharacter()
    {
       
        _rb.MovePosition(new Vector3(gameObject.transform.position.x +1* (_characterStats.horizontalMovementSpeed * _deltaPos.normalized.x * Time.fixedDeltaTime), gameObject.transform.position.y, gameObject.transform.position.z+1 * _characterStats.verticalMovementSpeed * Time.fixedDeltaTime));

    }

   

    //Must be call on uptade beacuse of GetButtonDown
    private void SetMovementInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseFirstPos = Input.mousePosition;

            Debug.Log("girdimfirst");
        }
        if (Input.GetMouseButton(0))
        {
            _mouseCurrentPos = Input.mousePosition;
            _deltaPos = _mouseCurrentPos - _mouseFirstPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseCurrentPos = Vector3.zero;
            _mouseFirstPos = Vector3.zero;
            _deltaPos = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
