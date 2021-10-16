using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private Animation _anim;
    private Score _score;
    
    private AudioManager _audioManager;
    [SerializeField] AudioClip _audioCoin;
    
    private void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        _score = GameObject.Find("Score").GetComponent<Score>();
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
        //_score.AddScore(50);
        _audioManager.PlaySound(_audioCoin);
        Destroy(gameObject, timer);
    }
}
