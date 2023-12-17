using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new(moveX, moveY);
        Vector3 moveVelocity = speed * Time.deltaTime * moveDirection;
        transform.position += moveVelocity;
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        GameManager.instance.totalBulletsFired++;
    }

    public void LoseLife()
    {
        GameManager.instance.PlayerHit();
    }
}
