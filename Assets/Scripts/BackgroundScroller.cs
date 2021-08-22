using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    //Notes x = -25.30006; go to x = 22.89994 

    private Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -25.30006)
        {
            transform.position = new Vector2(22.89994f, transform.position.y);
        }
    }
}
