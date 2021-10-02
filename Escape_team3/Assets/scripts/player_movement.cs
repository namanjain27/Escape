using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public float hori_F = 16f;
    public float vert_F = 20f;
    public health healthbar;
    public float health;
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
    }

    void gameover()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            health -= 5f;
            healthbar.SetHealth(health);
        }
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
