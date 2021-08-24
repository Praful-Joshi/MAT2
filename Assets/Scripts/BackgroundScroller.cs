using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    //Notes x = -25.30006; go to x = 22.89994 
    private float width;
    private float scrollSpeed = -2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -27.9)
        {
            transform.position = new Vector2(29.7f, transform.position.y);
        }
    }
}
