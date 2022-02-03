using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int maxHealth = 100;
    public static int currentHealth;

    float _hitTime = 1;
    float _hitTimer = 0;
    bool _canHit = true;

    Vector2 movement;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Hit timer hogy ne framenként kapj damaget, csak bizonyos idõközönként
        _hitTimer += Time.deltaTime;

        if (_hitTimer > _hitTime)
        {
            _canHit = true;
        } else
        {
            _canHit = false;
        }

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
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        if (!_canHit)
        {
            return;
        }

        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        _hitTimer = 0;
    }
}
