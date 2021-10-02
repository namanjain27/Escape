using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_scr : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public float hori_F = 16f;
    public float vert_F = 20f;
    public health healthbar;
    public float health;
    public GameObject gameOver_canvas;
    public GameObject rock_spawner;
    public AudioSource hit;
    public AudioSource gameOver_audio;
    public float score;
    public Text real_score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 100f;
    }

    private void Update()
    {
       if(health <= 0)
        {
            gameover();
        }
        score = Time.time;
        scorer();
    }

    void gameover()
    {
        rock_spawner.GetComponent<rockspawner>().enabled = false;
        gameOver_canvas.SetActive(true);
        gameOver_audio.Play();
        hit.enabled = false;
        gameObject.GetComponent<player_scr>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            health -= 5f;
            hit.Play();
            healthbar.SetHealth(health);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("base lava"))
        {
            health -= 3 * (Time.fixedDeltaTime);
            healthbar.SetHealth(health);
            hit.loop = true;
            hit.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        hit.loop = false;
    }

    void scorer()
    {
        real_score.text = score.ToString();
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKey("a"))
        {
            
            rb.AddForce(new Vector2(-hori_F,0), ForceMode2D.Force);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(hori_F, 0), ForceMode2D.Force);
        }
        if (Input.GetKey("w"))
        {
            
            rb.AddForce(new Vector2(0 , vert_F), ForceMode2D.Force);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(new Vector2(0, -vert_F), ForceMode2D.Force);
        }


        


    }
}
