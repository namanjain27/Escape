using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class power_up : MonoBehaviour
{
    public GameObject extra_health;
    public GameObject copy;
    public int time_to_give;
    public int interval;
    public bool received;
    Vector2 health_pos;
    public int destroy_time;
    public player_scr player;
    public AudioSource health_aud;
    
    //Y = 4.5
    //x = -11,11
    
    private void Start()
    {
        player = GetComponent<player_scr>();
        health_pos.x = 0f;
        health_pos.y = 5.3f;
        interval = 40;
        time_to_give = interval;
        received = false;
        destroy_time = 10;
    }
    void Update()
    {
        health_pos.x = Random.Range(-11f, 11f);
        if (player.score>= time_to_give)
        {
            received = false;
            copy = Instantiate(extra_health, health_pos, Quaternion.identity);
            interval += 15;
            time_to_give += interval;
        }
        if(player.score >= time_to_give - interval + destroy_time)
        {
            if (!received)
            {
                Destroy(copy);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == copy)
        {
            received = true;
            player.health += 20f;
            player.healthbar.SetHealth(player.health);
            health_aud.Play();
            if (player.health > 100f)
            {
                player.health = 100f;
            }
            Destroy(copy);
        }
    }
}
