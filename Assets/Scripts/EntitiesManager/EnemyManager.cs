using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    [SerializeField] private int moveSpeed = 3;
    private bool goToRight = false;
    private Vector3 _scale;

    private void Start()
    {
        _scale = transform.localScale;
    }

    private void Update()
    {
        if (goToRight) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
            if (_scale.x < 1) {
                _scale.x += Time.deltaTime * 8;
                if (_scale.x > 1)
                    _scale.x = 1;
                transform.localScale = _scale;
            }
        } else {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
            if (_scale.x > -1) {
                _scale.x -= Time.deltaTime * 8;
                if (_scale.x < -1)
                    _scale.x = -1;
                transform.localScale = _scale;
            }
        }
    }

    public void ChangeDirection()
    {
        goToRight = !goToRight;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player")) {
            col.gameObject.GetComponent<Health>().TakeDamage();
        }
    }
}