using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage()
    {
        Die();
    }

    protected override void Die()
    {
        //SCORE ++
        Destroy(gameObject);
    }
}