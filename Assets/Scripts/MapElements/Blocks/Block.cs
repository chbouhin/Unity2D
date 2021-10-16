using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private bool _destroyable;
    private AudioManager _audioManager;    
    
    private void Start()
    {
        _audioManager =  GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void Activate()
    {
        if (_destroyable)
        {
            _audioManager.PlaySound(_breakSound);
            Destroy(gameObject);
            return;
        }
        _audioManager.PlaySound(_hitSound);
    }
}
