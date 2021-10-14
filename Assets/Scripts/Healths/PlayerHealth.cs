using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Sprite _smallSprite;
    private Sprite _baseSprite;
    private int life = 2;

    private void Start()
    {
        base.Start();
        _baseSprite = _spriteRenderer.sprite;
    }

    public override void TakeDamage()
    {
        life--;
        if (life == 0)
            Die();
        _spriteRenderer.sprite = _smallSprite;
        TimerInvicibleTime = 0f;
    }
    
    public void GetBonus()
    {
        if (life == 1) {
            life++;
            _spriteRenderer.sprite = _baseSprite;
        }
    }

    public override void Die()
    {
        _gameManager.LooseGame();
    }
}