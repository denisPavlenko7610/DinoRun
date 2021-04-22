using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
   [SerializeField] private List<GameObject> _obstacles;
   [SerializeField] private float maxTimeBetweenSpawn;

   private void Start()
   {
      StartCoroutine("SpawnObject");
   }

   IEnumerator SpawnObject()
   {
      while (true)
      {
         yield return new WaitForSeconds(Random.Range(1, maxTimeBetweenSpawn));
         int randomObstacle = Random.Range(0, _obstacles.Count);
         Instantiate(_obstacles[randomObstacle], transform.position, transform.rotation);
      }
   }
}
