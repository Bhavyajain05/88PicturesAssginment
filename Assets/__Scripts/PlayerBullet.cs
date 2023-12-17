using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
        }
        base.OnTriggerEnter2D(other);
    }
}
