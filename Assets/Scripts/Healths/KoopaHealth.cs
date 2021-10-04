using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoopaHealth : Health
{
    private Score _score;
    private int scoreGive = 100;

    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    public override void TakeDamage()
    {
        Die();
    }

    public override void Die()
    {
        _score.AddScore(scoreGive);
        Destroy(gameObject);
    }
}