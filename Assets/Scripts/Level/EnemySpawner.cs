using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{ 
    public GameObject[] damagablePrefabs; 
    public float spawnTimer = 1f; 
    float timeToNextSpawn = 0f;

    public Collider2D spawnArea;

    private void Start()
    {
        spawnArea = this.GetComponent<Collider2D>();
    }

    void Update() 
    { 
        if (timeToNextSpawn <= 0) 
        { 
            SpawnEnemy(); 
            timeToNextSpawn += spawnTimer; 
        } 
        timeToNextSpawn -= Time.deltaTime; 
    }


    void SpawnEnemy() 
    {
        var go = damagablePrefabs[Random.Range(0, damagablePrefabs.Length)];

        Collider2D[] temp = new Collider2D[10];

        if(spawnArea.OverlapCollider(new ContactFilter2D(), temp) == 0)
        {
            Instantiate<GameObject>(go, transform.position, Quaternion.identity);
        }
    } 
}
