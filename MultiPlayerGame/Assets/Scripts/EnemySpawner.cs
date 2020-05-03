using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject spawnPoint;
    public int numOfEnemies;

    [HideInInspector]
    public List<SpawnPoint> enemySpawnPoints;

    void Start()
    {
        for(int i = 0; i < numOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8, 8f));
            Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
            SpawnPoint enemySpawnPoint = Instantiate(spawnPoint, spawnPosition, spawnRotation).GetComponent<SpawnPoint>();
            enemySpawnPoints.Add(enemySpawnPoint);
        }
        SpawnEnemies();
    }
    // TODO: Networking parameters and code in this method
    public void SpawnEnemies()
    {
        foreach(SpawnPoint sp in enemySpawnPoints)
        {
            GameObject newEnemy = Instantiate(enemy, sp.transform.position, sp.transform.rotation);
            newEnemy.name = "Steve#" + Random.Range(1000, 9999);
        }
    }

}
