using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health
{
    [SerializeField] private BossManager _bossManager;
    [SerializeField] private TaskKillBowser _taskKillBowser;
    private Score _score;
    private int scoreGive = 1000;
    private int life = 3;

    private new void Start()
    {
        base.Start();
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        life--;
        if (life == 0)
            Die();
        _bossManager.BeStronger();
        TimerInvicibleTime = 0f;
    }

    public override void Die()
    {
        _score.AddScore(scoreGive);
        _taskKillBowser.KillBowser();
        Destroy(gameObject);
    }
}