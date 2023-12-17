using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    public Transform target;
    public float rotationSpeed = 200.0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            transform.Rotate(0, 0, -rotateAmount * rotationSpeed * Time.deltaTime);
        }
        transform.position += transform.right * speed * Time.deltaTime;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().LoseLife();
            Destroy(gameObject);
        }
        base.OnTriggerEnter2D(other);
    }
}
