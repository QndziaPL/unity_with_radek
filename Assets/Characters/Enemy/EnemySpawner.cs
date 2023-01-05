using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    int numberOfObjects = 20;
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 5);
            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
