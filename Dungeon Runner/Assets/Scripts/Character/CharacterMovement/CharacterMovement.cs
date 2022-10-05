using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptable _characterStats;



    private Vector3 _mouseFirstPos;
    private Vector3 _mouseCurrentPos;
    private Vector3 deltaPos;

    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveCharacterVertical();
        //MoveCharacterHorizontal();

    }
    private void Update()
    {
        //SetMovementInputs();
    }



    private void MoveCharacterVertical()
    {
       
        _rb.MovePosition(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+1 * _characterStats.verticalMovementSpeed * Time.fixedDeltaTime));

    }

    private void MoveCharacterHorizontal()
    {
       
        if (Input.GetMouseButton(0))
        {
            Vector3 characterFirstPos = gameObject.transform.position;
            Debug.Log(characterFirstPos + "firstposofcharacter");
            gameObject.transform.position += new Vector3(_characterStats.horizontalMovementSpeed * deltaPos.normalized.x * Time.fixedDeltaTime, 0, 0);
            Vector3 characterCurrentPos = gameObject.transform.position;

            Debug.Log(characterFirstPos + "currentposofcharacter");
            float characterDeltaPos = Mathf.Atan2(characterCurrentPos.x, characterFirstPos.x) * Mathf.Rad2Deg;

            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y+characterDeltaPos, gameObject.transform.rotation.z);
            //Debug.Log(deltaPos.normalized);
        }
       


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
            deltaPos = _mouseCurrentPos - _mouseFirstPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseCurrentPos = Vector3.zero;
            _mouseFirstPos = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
