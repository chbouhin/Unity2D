using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _spawnEnemy;
    private float cooldownFireball = 3f;
    private float timerCooldownFireball = 0f;
    private float cooldownSpawnEnemy = 5f;
    private float timerCooldownSpawnEnemy = 0f;

    private void Update()
    {
        FireBall();
        SpawnEnemy();
    }

    private void FireBall()
    {
        if (timerCooldownFireball < cooldownFireball) {
            timerCooldownFireball += Time.deltaTime;
        } else {
            Instantiate(_fireBall, transform.position, Quaternion.identity);
            timerCooldownFireball -= cooldownFireball;
        }
    }

    private void SpawnEnemy()
    {
        if (timerCooldownSpawnEnemy < cooldownSpawnEnemy) {
            timerCooldownSpawnEnemy += Time.deltaTime;
        } else {
            Rigidbody2D rb2D = Instantiate(_spawnEnemy, transform.position + new Vector3(-3, 3, 0), Quaternion.identity).GetComponent<Rigidbody2D>();
            rb2D.AddForce(Vector2.up * -Vector2.right * 5);
            timerCooldownSpawnEnemy -= cooldownSpawnEnemy;
        }
    }
}