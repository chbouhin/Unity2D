using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    private Score _score;
    [SerializeField] private int scoreGive = 100;
    [SerializeField] private int life = 1;

    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        life -= 1;
        if (life <= 0)
            Die();
    }

    public override void Die()
    {
        _score.AddScore(scoreGive);
        Destroy(gameObject);
    }
}