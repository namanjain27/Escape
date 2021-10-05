using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour
{
    public Transform[] spawnPts;
    public GameObject rock;
    public float spawnTime;
    float timer;
    public player_scr player;

    private void Start()
    {
        spawnTime = 0.5f;
        timer = spawnTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            spawnRocks();
            timer = spawnTime;
        }
        if(player.score >= 40f)
        {
            if(player.score % 10 == 0)
            {
                spawnTime -= 0.01f;
                if (player.score > 170f) spawnTime -= 0.005f;
            }
           
        }
    }

    void spawnRocks()
    {
        int RandomIndex = Random.Range(0, spawnPts.Length);
        Instantiate(rock, spawnPts[RandomIndex].position, Quaternion.identity);
    }
}
