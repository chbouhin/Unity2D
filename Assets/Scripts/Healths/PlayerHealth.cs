using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    
    public override void TakeDamage()
    {
        Die();
    }

    public override void Die()
    {
        _gameManager.LooseGame();
    }
}