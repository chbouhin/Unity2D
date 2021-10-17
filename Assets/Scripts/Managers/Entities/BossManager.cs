using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Transform _leftPointMov;
    [SerializeField] private Transform _rightPointMov;
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _spawnEnemy;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private AudioClip _fireballSound;
    private AudioManager _audioManager;
    private bool _bossMusicPlaying = false;
    private Transform _player;
    private float cooldownFireball = 7f;
    private float timerCooldownFireball = 0f;
    private float cooldownSpawnEnemy = 15f;
    private float timerCooldownSpawnEnemy = 0f;
    private float moveSpeed = 2f;
    private bool goToRight = false;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_player.position.x > 336.5f)
        {
            FightBossStart();
            if (!_bossMusicPlaying) {
                _bossMusicPlaying = true;
                _audioManager.StopMusic();
                _audioManager.PlayMusic(_bossMusic);
            }
        }
    }

    private void FightBossStart()
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
            _audioManager.PlaySound(_fireballSound);
            Instantiate(_fireBall, transform.position, Quaternion.identity);
            timerCooldownFireball -= cooldownFireball;
        }
    }

    private void SpawnEnemy()
    {
        if (timerCooldownSpawnEnemy < cooldownSpawnEnemy) {
            timerCooldownSpawnEnemy += Time.deltaTime;
        } else {
            Rigidbody2D rb2D = Instantiate(_spawnEnemy, transform.position + new Vector3(-4, 3, 0), Quaternion.identity).GetComponent<Rigidbody2D>();
            rb2D.velocity = new Vector2(-2, 2);
            timerCooldownSpawnEnemy -= cooldownSpawnEnemy;
        }
    }

    public void BeStronger()
    {
        cooldownFireball *= 2f / 3f;
        cooldownSpawnEnemy *= 2f / 3f;
    }
}