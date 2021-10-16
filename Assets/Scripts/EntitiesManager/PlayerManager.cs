using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private KeyInput _keyInput;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _groundLayer;
    private float moveSpeed = 6f;
    private float jumpForce = 8f;
    private bool isJumping = false;
    private float longJump = 0.5f;
    private float timerLongJump = 0f;
    private Vector3 _scale;
    private bool goRight = true;

    private void Start()
    {
        _scale = transform.localScale;
    }

    private void Update()
    {
        Movement();
        TryJumping();
        if (_rb2d.velocity.y < -15)
            _rb2d.velocity = new Vector2(0, -15);
    }

    private void Movement()
    {
        if (Input.GetKey(_keyInput.left) && (transform.localScale.x > 0 || !Physics2D.OverlapBox(_wallCheck.position, _wallCheck.localScale, 0, _groundLayer))) {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
            if (transform.localScale.x > 0)
                goRight = false;
        }
        if (Input.GetKey(_keyInput.right) && (transform.localScale.x < 0 || !Physics2D.OverlapBox(_wallCheck.position, _wallCheck.localScale, 0, _groundLayer))) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
            if (transform.localScale.x < 0)
                goRight = true;
        }
        if (goRight) {
            if (_scale.x < 1) {
                _scale.x += Time.deltaTime * 8;
                if (_scale.x > 1)
                    _scale.x = 1;
                transform.localScale = _scale;
            }
        } else if (_scale.x > -1) {
            _scale.x -= Time.deltaTime * 8;
            if (_scale.x < -1)
                _scale.x = -1;
            transform.localScale = _scale;
        }
    }

    private void TryJumping()
    {
        if (Input.GetKey(_keyInput.jump)) {
            if (isJumping)
                StillJump();
            else if (_rb2d.velocity.y == 0 && Physics2D.OverlapBox(_groundCheck.position, _groundCheck.localScale, 0, _groundLayer))
                Jump();
        } else {
            timerLongJump = 0f;
            isJumping = false;
        }
    }

    public void StillJump()
    {
        if (timerLongJump < longJump && _rb2d.velocity.y > 0) {
            timerLongJump += Time.deltaTime;
            _rb2d.velocity = new Vector2(0, jumpForce);
        } else {
            timerLongJump = 0f;
            isJumping = false;
        }
    }

    public void Jump()
    {
        _rb2d.velocity = new Vector2(0, jumpForce);
        isJumping = true;
    }

    public bool IsFalling()
    {
        return _rb2d.velocity.y < 0;
    }
}