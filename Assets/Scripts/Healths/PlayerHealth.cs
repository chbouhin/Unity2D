using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage()
    {
        Die();
    }

    public override void Die()
    {
        print("PLAYER DIE - END");
    }
}