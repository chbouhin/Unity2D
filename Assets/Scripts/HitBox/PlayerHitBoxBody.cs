using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxBody : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerManager _playerManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy") && !_health.IsInvicible())
            _health.TakeDamage();

        if (col.transform.CompareTag("Button") && !_playerManager.IsFalling())
            col.gameObject.GetComponent<ButtonCanon>().JumpOnButton();
    }
}