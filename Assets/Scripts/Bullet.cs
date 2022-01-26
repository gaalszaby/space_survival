using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroySelf", 3f);
    }
    public GameObject hiteffect;
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("megutotte");
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(effect, 2f);
            Destroy(gameObject);
        }

    }
}
