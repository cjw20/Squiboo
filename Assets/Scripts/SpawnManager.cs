using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnTime;
    public float spawnOffset; //adds randomness to spawn interval
    float timeToNextSpawn;
    float timePassed;

    public Spawner[] spawners;
    int nextSpawner;
    void Start()
    {
        timeToNextSpawn = spawnTime + Random.Range(-spawnOffset, spawnOffset);
        nextSpawner = Random.Range(0, 3);
    }

    
    void Update()
    {  
        timePassed += Time.deltaTime;

        if (timePassed >= timeToNextSpawn)
        {
            spawners[nextSpawner].SpawnBlock();

            timePassed = 0;
            timeToNextSpawn = spawnTime + Random.Range(-spawnOffset, spawnOffset);
            nextSpawner = Random.Range(0, 3);
        }
    }
}
