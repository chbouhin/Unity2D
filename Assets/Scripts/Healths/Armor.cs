using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    private int health = 100;

    private void Start()
    {
        _healthBar.maxValue = health;
        _healthBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _healthBar.value = health;
        if (health <= 0)
            Destroy(gameObject);
    }
}