using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private Transform _player;
    
    private void Update()
    {
        transform.position = new Vector2(_player.position.x * moveSpeed, transform.position.y);
    }
}
