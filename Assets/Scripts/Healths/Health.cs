using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract void TakeDamage();

    public abstract void Die();

    private void OnMouseDown() {//TEMPORAIRE
        gameObject.GetComponent<Health>().TakeDamage();
    }
}