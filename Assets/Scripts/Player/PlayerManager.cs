using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Slider _healthBar;
    private int health = 100;
    private int damage = 25;

    private void Start()
    {
        _healthBar.maxValue = health;
        _healthBar.value = health;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<BulletManager>().damage = damage;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _healthBar.value = health;
        if (health <= 0)
            Debug.LogError("DEAD");
    }
}
