using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float speed = 7f;
    private float xScreenBound = -10.16f;
    private int health = 100;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xScreenBound)
        {
            PlayerController.obstaclesPassed += 1;
            Destroy(this.gameObject);
        }

        if (BulletController.score > 200)
        {
            speed = 10f;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.Play("Destroy");
            FindObjectOfType<SoundManager>().Play("Destroy");
            float delay = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("Die", delay);
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
