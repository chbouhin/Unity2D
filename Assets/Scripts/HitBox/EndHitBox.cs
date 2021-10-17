using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHitBox : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _player;
    [SerializeField] private BoxCollider2D _bigMario;
    [SerializeField] private BoxCollider2D _smallMario;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _sound;
    [HideInInspector] public bool end = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player")) {
            _audioManager.PlaySound(_sound);
            end = true;
            _bigMario.enabled = false;
            _smallMario.enabled = false;
            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = new Vector2(0, 0);
            _player.position = new Vector2(_player.position.x, -6);
        }
    }

    private void Update()
    {
        if (end) {
            _player.position += _player.transform.right * 2 * Time.deltaTime;
            if (_player.position.x >= 374) {
                _gameManager.WinGame();
                end = false;
            }
        }
    }
}