using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    public float timeElapsed; //total time game has gone on
    int lastSpawnChange = 0; //time when last spawn rate change occured
    int lastSpeedChange = 0;

    public float timeAdjustment;
    public float speedAdjustment;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if ((int)timeElapsed % 10 == 0 && (int)timeElapsed != lastSpawnChange)
        {
            lastSpawnChange = (int)timeElapsed; //prevents time from changing multiple times in a second
            spawnManager.spawnTime -= timeAdjustment; 
            //decreases time between spawns every 10 seconds
        }

        if ((int)timeElapsed % 15 == 0 && (int)timeElapsed != lastSpeedChange)
        {
            lastSpeedChange = (int)timeElapsed; 
            foreach(Spawner spawner in spawnManager.spawners)
            {
                spawner.blockSpeed += speedAdjustment;
            }            
        }

        GameControl.control.UpdateTime((int)timeElapsed);
    }
}
