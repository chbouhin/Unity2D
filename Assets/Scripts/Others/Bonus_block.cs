using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_block : MonoBehaviour
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private AudioClip _hitSound;
    private AudioManager _audioManager;
    
    [SerializeField] private Item _bonusItem;
    [SerializeField] private Sprite _usedSprite;
    private bool _used = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        item.transform.position = parent.position + new Vector3(0, 0, 1);

        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = _usedSprite;
    }
}
