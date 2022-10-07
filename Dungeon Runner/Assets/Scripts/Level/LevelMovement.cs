using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -15), 15 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelGenerator.Instance.SpawnNewTile();

    }


    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
