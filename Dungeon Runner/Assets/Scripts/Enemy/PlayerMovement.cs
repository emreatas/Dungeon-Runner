using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float jumpPower;
    public GameObject caps;
    void Update()
    {
        playerMove();
    }
    void playerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 way = Vector3.Normalize(new Vector3(z, 0, -x));
        transform.Translate(way * walkSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && caps.transform.position.y < 2)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        }
    }
}
