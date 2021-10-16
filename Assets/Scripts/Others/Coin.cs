using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] private Animation _anim;
    private Score _score;
    
    private AudioManager _audioManager;
    [SerializeField] AudioClip _audioCoin;
    
    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            _score.AddScore(50);
            _audioManager.PlaySound(_audioCoin);
            Destroy(gameObject);
        }
    }

    public override void Init(AudioManager manager)
    {
        _audioManager = manager;
        _audioManager.PlaySound(_audioCoin);
        _anim.Play("CoinPopUp");
        Destroy(gameObject, _anim.clip.length);
    }
}
