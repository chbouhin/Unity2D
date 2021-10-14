using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxBody : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy") && _health.IsInvicible())
            _health.TakeDamage();

        if (col.transform.CompareTag("Button"))
            col.gameObject.GetComponent<ButtonCanon>().JumpOnButton();
    }
}