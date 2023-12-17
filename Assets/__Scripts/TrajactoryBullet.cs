using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajactoryBullet : Bullet
{
    public float launchAngle = 45.0f; 
    public float gravity = -9.8f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float launchAngleRadians = launchAngle * Mathf.Deg2Rad;
        float initialVelocityX = speed * Mathf.Cos(launchAngleRadians);
        float initialVelocityY = speed * Mathf.Sin(launchAngleRadians);
        rb.velocity = new Vector2(initialVelocityX, initialVelocityY);
    }

    private void Update()
    {
        Vector2 velocity = rb.velocity;
        velocity += new Vector2(0, gravity) * Time.deltaTime;
        rb.velocity = velocity;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().LoseLife();
            Destroy(gameObject);
        }
        base.OnTriggerEnter2D(other);
    }
}
