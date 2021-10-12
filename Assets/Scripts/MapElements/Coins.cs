using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Score _score;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            _score.AddScore(50);
            Destroy(gameObject);
        }
    }
}