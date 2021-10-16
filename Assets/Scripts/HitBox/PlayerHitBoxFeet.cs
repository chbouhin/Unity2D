using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxFeet : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("EnemyHead") && col.name != "Bowser") {
            col.gameObject.transform.parent.GetComponent<Health>().TakeDamage();
            _playerManager.Jump(false);
        }
    }
}