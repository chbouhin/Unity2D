using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Wall") || col.transform.CompareTag("Enemy") || col.transform.CompareTag("InvisibleWall"))
            _enemyManager.ChangeDirection();
    }
}