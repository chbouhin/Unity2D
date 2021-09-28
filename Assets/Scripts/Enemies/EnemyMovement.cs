using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    private int moveSpeed = 5;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
    }
}
