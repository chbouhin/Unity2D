using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _baseSprite;
    [SerializeField] private Sprite _smallSprite;
    private int life = 2;
    
    public override void TakeDamage()
    {
        life--;
        if (life == 0)
            Die();
        _spriteRenderer.sprite = _smallSprite;
    }
    
    public void GetBonus()
    {
        life++;
        _spriteRenderer.sprite = _baseSprite;
    }

    public override void Die()
    {
        _gameManager.LooseGame();
    }
}