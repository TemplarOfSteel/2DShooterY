using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour { public GameObject[] damagablePrefabs; public float spawnTimer = 1f; float timeToNextSpawn = 0f; void Update() { if (timeToNextSpawn <= 0) { SpawnEnemy(); timeToNextSpawn += spawnTimer; } timeToNextSpawn -= Time.deltaTime; } 
    
    void SpawnEnemy() 
    {
        var go = damagablePrefabs[Random.Range(0, damagablePrefabs.Length)];

        Instantiate<GameObject>(go, transform.position, Quaternion.identity); 
    } 
}
