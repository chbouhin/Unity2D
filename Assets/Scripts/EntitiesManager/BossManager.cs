using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Transform _leftPointMov;
    [SerializeField] private Transform _rightPointMov;
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _spawnEnemy;
    private float cooldownFireball = 6f;
    private float timerCooldownFireball = 0f;
    private float cooldownSpawnEnemy = 10f;
    private float timerCooldownSpawnEnemy = 0f;
    private float moveSpeed = 3f;
    private bool goToRight = false;

    private void Update()
    {
        if (goToRight) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= _rightPointMov.position.x)
                goToRight = false;
        } else {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
            if (transform.position.x <= _leftPointMov.position.x)
                goToRight = true;
        }
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
            rb2D.velocity = new Vector2(-3, 3);
            timerCooldownSpawnEnemy -= cooldownSpawnEnemy;
        }
    }

    public void BeStronger()
    {
        cooldownFireball *= 2f / 3f;
        cooldownSpawnEnemy *= 2f / 3f;
    }
}