using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    [SerializeField] private int scoreGive = 100;
    [SerializeField] private AudioClip _stompSound;
    private Score _score;
    private AudioManager _audioManager;

    private new void Start()
    {
        base.Start();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        _audioManager.PlaySound(_stompSound);
        Die();
    }

    public override void Die()
    {
        _score.AddScore(scoreGive);
        Destroy(gameObject);
    }
}