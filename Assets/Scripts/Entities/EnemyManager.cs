using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected Weapon _weapon;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceMovement;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);
        if (distance > distanceMovement)
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
        if (distance < _weapon.range && _weapon.CanAttack())
            _weapon.Attack(_player.transform.position);
    }
}