using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract void TakeDamage();

    protected abstract void Die();
}