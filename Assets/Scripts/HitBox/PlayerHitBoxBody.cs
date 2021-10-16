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

        if (col.transform.CompareTag("Block") && !_playerManager.IsFalling())
            col.gameObject.GetComponent<Block>().Activate();

        if (col.transform.CompareTag("BonusBlock") && !_playerManager.IsFalling())
            col.gameObject.GetComponent<Bonus_block>().Activate();
    }
}