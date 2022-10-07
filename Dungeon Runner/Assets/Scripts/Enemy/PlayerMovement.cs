using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float jumpPower;
    public GameObject caps;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        playerMove();
    }
    void Update()
    {
        
    }
    void playerMove()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        _rb.MovePosition(new Vector3(gameObject.transform.position.x + x * walkSpeed * Time.fixedDeltaTime, gameObject.transform.position.y, gameObject.transform.position.z + z * walkSpeed * Time.fixedDeltaTime));
    }
}
