using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxFeet : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    public bool isTouchingGround = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy") && _playerManager.IsFalling()) {
            col.gameObject.GetComponent<Health>().TakeDamage();
            _playerManager.Jump();
        }

        if (col.transform.CompareTag("Wall"))
            isTouchingGround = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Wall"))
            isTouchingGround = false;
    }
}