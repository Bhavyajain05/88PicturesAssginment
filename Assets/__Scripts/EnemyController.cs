using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public GameObject[] bulletPrefabs;
    public Transform bulletSpawnPoint;
    public float health = 100.0f;

    private float moveDirection = 1.0f;
    private float bulletCooldown = 2.0f;
    private float bulletTimer;
    [SerializeField] float ScreenTop;
    [SerializeField] Slider HealthSlider;

    private void Start()
    {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;
    }

    private void Update()
    {
        MoveEnemy();
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletCooldown)
        {
            ShootBullet();
            bulletTimer = 0;
        }

        HealthSlider.value = health;
    }

    private void MoveEnemy()
    {
        if (transform.position.y >= ScreenTop)
        {
            moveDirection = -1.0f;
        }
        else if (transform.position.y <= -ScreenTop)
        {
            moveDirection = 1.0f;
        }
        transform.position += new Vector3(0, moveSpeed * moveDirection * Time.deltaTime, 0);
    }

    private void ShootBullet()
    {
        int bulletIndex = DetermineBulletType();
        Instantiate(bulletPrefabs[bulletIndex], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private int DetermineBulletType()
    {
        int currentLevel = GameManager.instance.currentLevel;
        float healthPercentage = health / 100.0f;

        if (currentLevel == 1)
        {
            return 0;
        }
        else if (currentLevel == 2)
        {
            if (healthPercentage > 0.5f)
            {
                return 0;
            }
            else
            {
                return 1; 
            }
        }
        else if (currentLevel == 3)
        {
            if (healthPercentage > 0.66f)
            {
                return 0; 
            }
            else if (healthPercentage > 0.33f)
            {
                return 1; 
            }
            else
            {
                return 2; 
            }
        }
        else
        {
            return 0;
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            UIManager.instance.ShowLevelCompleteScreen();
        }
    }
}
