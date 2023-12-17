using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : Bullet
{
    private void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
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
