using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : Health
{
    public override void TakeDamage()
    {
        Die();
    }

    protected override void Die()
    {
        print("PLAYER DIE - END");
    }
}