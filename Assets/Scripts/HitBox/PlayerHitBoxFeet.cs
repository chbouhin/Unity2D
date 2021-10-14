using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxFeet : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy") && _playerManager.IsFalling() && col.name != "Bowser") {
            col.gameObject.GetComponent<Health>().TakeDamage();
            _playerManager.Jump();
        }
    }
}