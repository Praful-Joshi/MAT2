using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool hasShoot = false;
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (bullet == null)
        {
            Invoke("hasShootFalse", 0.5f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 9.46 && !hasShoot)
        {
            hasShoot = true;
            Shoot();
        }
    }

    void Shoot()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    void hasShootFalse()
    {
        hasShoot = false;
    }
}
