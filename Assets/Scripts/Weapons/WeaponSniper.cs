using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSniper : Weapon
{
    [SerializeField] private GameObject _bullet;

    protected override void Start()
    {
        range = 100f;
        damage = 10;
        cooldown = 1f;
        base.Start();
    }

    public override void Attack(Vector3 direction)
    {
        BulletManager bullet = Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<BulletManager>();
        bullet.SetDirection(direction);
        bullet.mySide = gameObject.tag;
        bullet.damage = damage;
        ResetCooldown();
    }
}