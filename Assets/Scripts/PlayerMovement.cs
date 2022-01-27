using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int maxHealth = 100;
    public int currentHealth;
    public Text health;
    public Text gameOver;

    Vector2 movement;

    private void Start()
    {
        currentHealth = maxHealth;
        gameOver.enabled = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        health.text = currentHealth.ToString();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
            if (currentHealth == 0)
            {
                gameOver.enabled = true;
            }
        }
    }

    private void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        } else
        {
            currentHealth = 0;
        }

    }
}
