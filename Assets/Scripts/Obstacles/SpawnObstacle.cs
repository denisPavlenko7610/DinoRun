using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private float _minTimeBetweenSpawn;
    [SerializeField] private float _maxTimeBetweenSpawn;

    private List<GameObject> _instantiatedObstacles;
    private Camera _camera;
    private float _disableTime = 0.5f;
    private float _timeBetweenSpawn;
    private void Start()
    {
        _camera = Camera.main;
        InitListOfObstacles();
        StartCoroutine("SpawnObjects");
        StartCoroutine("DisableObjects");
    }

    private void InitListOfObstacles()
    {
        _instantiatedObstacles = new List<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            int randomNumber = Random.Range(0, _obstacles.Count);
            GameObject obstacleObject =
                Instantiate(_obstacles[randomNumber], transform.position, transform.rotation, transform);
            _instantiatedObstacles.Add(obstacleObject);
            _obstacles[randomNumber].gameObject.SetActive(false);
        }
    }

    private void DisableInvisibleObjects()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        for (int i = 0; i < _instantiatedObstacles.Count; i++)
        {
            if (_instantiatedObstacles[i].activeSelf)
            {
                if (_instantiatedObstacles[i].transform.position.x < disablePoint.x)
                {
                    _instantiatedObstacles[i].transform.position = transform.position;
                    _instantiatedObstacles[i].SetActive(false);
                } 
            }
        }
    }

    IEnumerator DisableObjects()
    {
        while (GameManager._isGameStop == false)
        {
            if (GameManager._isGameStart)
            {
                DisableInvisibleObjects();
            }
            
            yield return new WaitForSeconds(_disableTime);
        }
    }

    IEnumerator SpawnObjects()
    {
        while (GameManager._isGameStop == false)
        {
            if (GameManager._isGameStart)
            {
                _timeBetweenSpawn = Random.Range(_minTimeBetweenSpawn, _timeBetweenSpawn + 1);
                int randomObstacle = Random.Range(0, _instantiatedObstacles.Count);
                _instantiatedObstacles[randomObstacle].gameObject.SetActive(true);
            }
            
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}