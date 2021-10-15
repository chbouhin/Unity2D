using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private PlayerHealth _player;
    private Vector3 _directionVector;
    private int moveSpeed = 5;

    private void Start()
    {
        Destroy(gameObject, 10f);
        _directionVector = (GameObject.Find("Player").transform.position - transform.position).normalized;
        _player = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        transform.Translate(_directionVector * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            _player.TakeDamage();
            Destroy(gameObject);
        } else if (col.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }
}