using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]private CharacterStatsScriptable _characterStats;



    private Vector3 _mouseFirstPos;
    private Vector3 _mouseCurrentPos;
    private float deltaPos;


    private void FixedUpdate()
    {
        MoveCharacterVertical();
    }



    private void MoveCharacterVertical()
    {
        gameObject.transform.position += new Vector3(0, 0, 1 * _characterStats.verticalMovementSpeed*Time.fixedDeltaTime);
    }

    private void MoveCharacterHorizontal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseFirstPos = Input.mousePosition;
            if (Input.GetMouseButton(0))
            {
                //_mouseCurrentPos=
            }

        }
        
    }
}
