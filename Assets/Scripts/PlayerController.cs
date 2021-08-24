using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 8f;
    public static int obstaclesPassed = 0;
    private Animator anim;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public LobbyController lobbyController;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * moveSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<SoundManager>().Play("PlayerShoot");
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            anim.Play("Destroy");
            FindObjectOfType<SoundManager>().Play("Destroy");
            float delay = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("DestroyPlayer", delay);
            Invoke("FreezeGame", 0.5f);
            lobbyController.GameOver();
        }
    }

    void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
    }
}
