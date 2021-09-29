using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _cooldownAttack;
    private GameObject _player;
    private int health = 100;
    private int damage = 5;
    private float cooldownAttack = 1.5f;
    private float timerCooldownAttack = 0f;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _healthBar.maxValue = health;
        _healthBar.value = health;
        _cooldownAttack.maxValue = cooldownAttack;
        _cooldownAttack.value = timerCooldownAttack;
    }

    private void Update()
    {
        if (timerCooldownAttack < cooldownAttack) {
            timerCooldownAttack += Time.deltaTime;
            _cooldownAttack.value = timerCooldownAttack;
        } else if (Vector2.Distance(transform.position, _player.transform.position) < 1) {
            _player.GetComponent<PlayerManager>().TakeDamage(damage);
            timerCooldownAttack = 0;
            _cooldownAttack.value = timerCooldownAttack;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
        _healthBar.value = health;
    }
}
