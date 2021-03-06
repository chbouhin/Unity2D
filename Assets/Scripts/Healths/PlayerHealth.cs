using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _bigMario;
    [SerializeField] private GameObject _smallMario;
    [SerializeField] private AudioClip _shrinkSound;
    private AudioManager _audioManager;
    private int life = 2;

    private new void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        base.Start();
    }

    private new void Update()
    {
        base.Update();
        if (life > 0 && transform.position.y <= -11)
            Die();
    }

    public override void TakeDamage()
    {
        life--;
        if (life == 0) {
            Die();
        } else {
            TimerInvicibleTime = 0f;
            _bigMario.SetActive(false);
            _smallMario.SetActive(true);
            _audioManager.PlaySound(_shrinkSound);
        }
    }

    public void GetBonus()
    {
        if (life == 1) {
            life++;
            _bigMario.SetActive(true);
            _smallMario.SetActive(false);
        }
    }

    public override void Die()
    {
        _gameManager.LooseGame();
        life = 0;
    }
}