using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    [SerializeField] private int scoreGive = 100;
    private Score score;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        Die();
    }

    public override void Die()
    {
        score.AddScore(scoreGive);
        Destroy(gameObject);
    }
}