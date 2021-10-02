using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour
{
    public Transform[] spawnPts;
    public GameObject rock;
    public float spawnTime;

    private void Start()
    {
        spawnTime = 0.5f;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            spawnRocks();
            spawnTime = 0.5f;
        }
        
    }

    void spawnRocks()
    {
        int RandomIndex = Random.Range(0, spawnPts.Length);
        Instantiate(rock, spawnPts[RandomIndex].position, Quaternion.identity);
    }
}
