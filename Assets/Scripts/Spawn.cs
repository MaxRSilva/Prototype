using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy enemy;
    public float spawnInterval;
    public int minSpawnAmount;
    public int maxSpawnAmount;
    public float radius;


    float timeCount;
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");     
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount > spawnInterval) 
        {
            SpawnEnemies();
            timeCount = 0;
        
        
        }
    }
    void SpawnEnemies()
    {
        int enemiesSpawn = Random.Range(minSpawnAmount, maxSpawnAmount);

        for (int i = 0; i < enemiesSpawn; i++)
        {
            Vector2 enemyPos = (Vector2)player.transform.position + Random.insideUnitCircle * radius;
            Instantiate(enemy, enemyPos, Quaternion.identity);
        }
    }
}
