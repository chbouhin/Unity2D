using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoombaHealth : Health
{
    [SerializeField] private GameObject _toInvoke;
    private Score _score;
    private int scoreGive = 150;

    private new void Start()
    {
        base.Start();
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
        Instantiate(_toInvoke, transform.position, Quaternion.identity);
        Instantiate(_toInvoke, transform.position, Quaternion.identity);
    }
}