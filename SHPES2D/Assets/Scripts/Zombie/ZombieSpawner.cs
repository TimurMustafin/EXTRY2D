using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float distanceBetweenEnemies;
    [SerializeField]
    private int numberOfEnemies;

    private void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, transform.position + Vector3.right * i * distanceBetweenEnemies, Quaternion.identity);
        }        
    }

}
