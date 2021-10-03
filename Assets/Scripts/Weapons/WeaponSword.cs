using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : Weapon
{
    private string target;

    protected override void Start()
    {
        damage = 10;
        cooldown = 0.5f;
        range = 2f;
        if (gameObject.tag == "Enemy")
            target = "Player";
        else
            target = "Enemy";
        base.Start();
    }

    public override void Attack(Vector3 direction)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D enemy in enemies)
            if (enemy.tag == target)
                enemy.GetComponent<Armor>().TakeDamage(damage);
        ResetCooldown();
    }

    private void OnDrawGizmos()//TEMPORAIRE
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}