using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;


    public float spawnTimer = 1f;
    float timeToNextSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){ if (timeToNextSpawn <= 0) { SpawnEnemy(); timeToNextSpawn += spawnTimer; } timeToNextSpawn -= Time.deltaTime;}

    void SpawnEnemy()
    {
        Instantiate<GameObject>(
            enemyPrefab, 
            transform.position, 
            Quaternion.identity);
    }
}
