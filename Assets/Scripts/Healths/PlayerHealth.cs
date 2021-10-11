using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _smallSprite;
    private int life = 2;
    
    public override void TakeDamage()
    {
        life--;
        if (life == 0)
            Die();
        _spriteRenderer.sprite = _smallSprite;
    }

    public override void Die()
    {
        _gameManager.LooseGame();
    }

    public void GetBigger()
    {
        life += 1;
    }
}