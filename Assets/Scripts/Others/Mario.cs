using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Mario : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerManager _playerManager;

    private void Update()
    {
        _animator.SetBool("IsMoving", _playerManager.move);
        _animator.SetBool("IsJumping", _playerManager.IsJumping());
        _animator.SetBool("IsFalling", _playerManager.IsFalling());
    }
}
