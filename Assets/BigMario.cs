using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BigMario : MonoBehaviour
{
    [SerializeField] private Sprite _idleMario;
    [SerializeField] private Sprite _jumpingMario;
    [SerializeField] private Sprite _fallingMario;
    private PlayerManager _playerManager;
    private bool _isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerManager.IsFalling())
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                GetComponent<SpriteRenderer>().sprite = _fallingMario;
            }
        } else if (_playerManager.IsJumping())
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                GetComponent<SpriteRenderer>().sprite = _jumpingMario;
            }
        }
        else
        {
            if (!_isGrounded)
            {
                _isGrounded = true;
                GetComponent<SpriteRenderer>().sprite = _idleMario;
            }
        }
    }
}
