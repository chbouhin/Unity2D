using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health
{
    [SerializeField] private BossManager _bossManager;
    private Score _score;
    private int scoreGive = 500;
    private int life = 3;

    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        life -= 1;
        if (life <= 0)
            Die();
        _bossManager.BeStronger();
    }

    public override void Die()
    {
        _score.AddScore(scoreGive);
        Destroy(gameObject);
    }
}