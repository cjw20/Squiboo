using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{     
    public Vector2 spawnDirection;
    public float blockSpeed;
    public GameObject[] spawnPool;
    void Start()
    {        
        spawnDirection = this.gameObject.transform.position.normalized;
    }   

    public void SpawnBlock()
    {
        int randomBlock = Random.Range(0, spawnPool.Length - 1);
        GameObject newBlock = Instantiate(spawnPool[randomBlock], this.gameObject.transform);
        newBlock.GetComponent<Rigidbody2D>().AddForce(spawnDirection * -blockSpeed);        
    }
}
