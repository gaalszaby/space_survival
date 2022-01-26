using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public float cooldown = 5f;
    float nextfire;

    public float bulletforce = 20f;

    // Update is called once per frame
    void Update()



    {
        Shoot();
    }
    void Shoot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + cooldown;
            GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletforce, ForceMode2D.Impulse);
        }
    }
}
