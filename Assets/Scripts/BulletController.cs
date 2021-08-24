using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private int damage = 100;
    public static int score = 0;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    private void Update()
    {
        if (transform.position.x > 11.02)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ObstacleController enemy = hitInfo.GetComponent<ObstacleController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            score += 10;
        }
        if (hitInfo.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }

}
