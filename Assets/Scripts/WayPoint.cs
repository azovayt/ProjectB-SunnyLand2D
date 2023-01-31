using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public float moveSpeed;
    public Transform wayPoint1, wayPoint2;
    bool wayPointRight;
    Rigidbody2D rb;
    public SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        wayPoint1.parent = null;
        wayPoint2.parent = null;

        wayPointRight = true;
    }

    private void Update()
    {
        if (wayPointRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sr.flipX = true;
            if (transform.position.x > wayPoint1.position.x)
            {
                wayPointRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            sr.flipX = false;
            if (transform.position.x < wayPoint2.position.x)
            {
                wayPointRight = true;
            }
        }
    }
}
