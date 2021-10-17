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
    private bool _isJumping = false;
    private bool _isFalling = false;
    
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
            if (!_isFalling)
            {
                _isFalling = true;
                _isJumping = false;
                GetComponent<SpriteRenderer>().sprite = _fallingMario;
            }
        } else if (_playerManager.IsJumping())
        {
            if (!_isJumping)
            {
                _isJumping = true;
                _isFalling = false;
                GetComponent<SpriteRenderer>().sprite = _jumpingMario;
            }
        }
        else
        {
            if (_isJumping)
            {
                _isJumping = false;
                GetComponent<SpriteRenderer>().sprite = _idleMario;
            } else if (_isFalling)
            {
                _isFalling = false;
                GetComponent<SpriteRenderer>().sprite = _idleMario;
            }
        }
    }
}
