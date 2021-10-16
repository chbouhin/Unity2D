using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoombaHealth : Health
{
    [SerializeField] private GameObject _toInvoke;
    [SerializeField] private AudioClip _stompSound;
    private AudioManager _audioManager;
    private Score _score;
    private int scoreGive = 150;

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
        Instantiate(_toInvoke, transform.position, Quaternion.identity);
        Instantiate(_toInvoke, transform.position, Quaternion.identity);
    }
}