using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_block : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    private AudioManager _audioManager;
    
    [SerializeField] private Item _bonusItem;
    [SerializeField] private Sprite _usedSprite;
    private bool _used = false;
    
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void Activate()
    {
        var parent = gameObject.transform;

        if (_used)
            return;
        _used = true;
        _audioManager.PlaySound(_hitSound);
        var item = Instantiate(_bonusItem);
        item.transform.parent = parent;
        item.Init(_audioManager);
        item.transform.position = parent.position + new Vector3(0f, 0.3f, 1f);

        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = _usedSprite;
    }
}
