using System;
using System.Collections;
using System.Collections.Generic;
using Others;
using UnityEngine;

public class Bonus_block : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerObject;
    [SerializeField] private AudioClip hitSound;
    private AudioManager audioManager;
    
    [SerializeField] private Item bonusItem;
    [SerializeField] private Sprite usedSprite;
    private bool used = false;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = audioManagerObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()//TEMPORAIRE
    {
        gameObject.GetComponent<Bonus_block>().Activate();
    }
    
    public void Activate()
    {
        var parent = gameObject.transform;

        if (used)
            return;
        audioManager.PlaySound(hitSound);
        var item = Instantiate(bonusItem);
        item.transform.parent = parent;
        item.Init(audioManager);
        item.transform.position = parent.position + new Vector3(0, 0, 1);
        used = true;

        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = usedSprite;
    }
}
