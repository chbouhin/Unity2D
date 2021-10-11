using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    private float moveSpeed = 6f;
    private float jumpForce = 10f;
    private bool isJumping = false;
    private float longJump = 0.5f;
    private float timerLongJump = 0f;

    private void Update()
    {
        Movement();
        TryJumping();
        if (_rb2d.velocity.y < -15)
            _rb2d.velocity = new Vector2(0, -15);
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    private void TryJumping()
    {
        if (Input.GetKey(KeyCode.Z)) {
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
        return _rb2d.velocity.y <= 0;
    }
}