using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    [SerializeField] private int moveSpeed = 3;
    private bool goToRight = false;
    private Vector3 _scale;
    private float xPos;

    private void Start()
    {
        xPos = transform.localScale.x;
        _scale = transform.localScale;
    }

    private void Update()
    {
        if (goToRight) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
            if (_scale.x < -xPos) {
                _scale.x += Time.deltaTime * 8;
                if (_scale.x > -xPos)
                    _scale.x = -xPos;
                else if (-0.01f > _scale.x && _scale.x > 0.01f)
                    _scale.x = 0.01f;
                transform.localScale = _scale;
            }
        } else {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
            if (_scale.x > xPos) {
                _scale.x -= Time.deltaTime * 8;
                if (_scale.x < xPos)
                    _scale.x = xPos;
                else if (-0.01f > _scale.x && _scale.x > 0.01f)
                    _scale.x = -0.01f;
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