using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] private Animation _anim;
    [SerializeField] AudioClip _audioCoin;
    private AudioManager _audioManager;
    private TaskCoins _taskCoins;
    private Score _score;
    
    private void Start()
    {
        _audioManager =  GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _score = GameObject.Find("Score").GetComponent<Score>();
        _taskCoins = GameObject.Find("CoinsTask").GetComponent<TaskCoins>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            Use(0);
    }

    public override void Init(AudioManager manager)
    {
        _audioManager = manager;
        _anim.Play("CoinPopUp");
        Use(_anim.clip.length);
    }

    private void Use(float timer)
    {
        _score.AddScore(50);
        _taskCoins.AddCoin();
        _audioManager.PlaySound(_audioCoin);
        Destroy(gameObject, timer);
    }
}
