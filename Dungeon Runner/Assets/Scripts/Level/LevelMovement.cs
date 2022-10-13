using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType
{
    Obstacle,
    NonObstacle,
    Market
}
public class LevelMovement : MonoBehaviour
{
    [SerializeField] private TileType tileType;

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -30),
            15 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (tileType)
            {
                case TileType.Obstacle:
                    LevelGenerator.Instance.SpawnObstacleTile();
                    break;
                case TileType.NonObstacle:
                    LevelGenerator.Instance.SpawnNonObstacleTile();
                    break;
                case TileType.Market:
                    break;
            }

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
