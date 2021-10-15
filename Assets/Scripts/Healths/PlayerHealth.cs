using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _bigMario;
    [SerializeField] private GameObject _smallMario;
    private int life = 2;

    private new void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (transform.position.y <= -11)
            Die();
    }

    public override void TakeDamage()
    {
        life--;
        if (life == 0)
            Die();
        else {
            _bigMario.SetActive(false);
            _smallMario.SetActive(true);
            TimerInvicibleTime = 0f;
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
    }
}