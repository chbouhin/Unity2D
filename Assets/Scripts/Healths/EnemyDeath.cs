using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    public override void Die()
    {
        //SCORE ++
        Destroy(gameObject);
    }
}