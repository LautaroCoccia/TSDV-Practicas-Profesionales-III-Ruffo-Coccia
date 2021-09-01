﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> barrelPositions;
    [SerializeField] static int enemiesAlive;
    [SerializeField] int maxEnemiesAlive;
    [SerializeField] float minTimeToSpawn;
    [SerializeField] float maxTimeToSpawn;
    [SerializeField] float actualTime;
    [SerializeField] float timeToSpawn;
    [SerializeField] GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive < maxEnemiesAlive)
        {
            actualTime += Time.deltaTime;
        }
        if(actualTime >= timeToSpawn)
        {
            actualTime = 0;
            timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, newEnemy.transform.position.z);
        newEnemy.gameObject.GetComponent<EnemyFSM>().SetObstaclesList(barrelPositions);
        enemiesAlive++;
    }
}
