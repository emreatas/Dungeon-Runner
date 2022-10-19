using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelMovement : MonoBehaviour
{
    [SerializeField] private TileType tileType;

    [SerializeField] private List<GameObject> _collectableItem;
    [SerializeField] private List<GameObject> _collectableItemLane;
    [SerializeField] private List<GameObject> _enemySpawnPoint;

    private int _movement;
    public enum TileType
    {
        Obstacle,
        NonObstacle,
        Market
    }






    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -30),
            _movement * Time.deltaTime);
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



    private void OnEnable()
    {

        _movement = 15;

        GameManager.Dead += GameManager_Dead;




        switch (tileType)
        {
            case TileType.Obstacle:
                if (_collectableItem.Count != 0)
                {

                    for (int i = 0; i < _collectableItem.Count; i++)
                    {
                        _collectableItem[i].SetActive(true);
                    }
                }
                if (_collectableItemLane.Count != 0)
                {
                    int flag = 0;
                    flag = Random.Range(0, _collectableItemLane.Count);

                    for (int i = 0; i < _collectableItemLane.Count; i++)
                    {
                        _collectableItemLane[i].SetActive(false);
                    }
                    _collectableItemLane[flag].SetActive(true);
                }
                break;
            case TileType.NonObstacle:

                if (_enemySpawnPoint.Count != 0)
                {
                    int flag = 0;
                    for (int i = 0; i < _enemySpawnPoint.Count; i++)
                    {
                        _enemySpawnPoint[i].SetActive(false);
                    }

                    _enemySpawnPoint[flag].SetActive(true);
                    _enemySpawnPoint[(flag + 2) % _enemySpawnPoint.Count].SetActive(true);
                }

                break;
            case TileType.Market:
                break;
        }





    }

    private void GameManager_Dead()
    {
        _movement = 0;

    }

    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
