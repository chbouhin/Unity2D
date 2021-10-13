using System.Collections;
using System.Collections.Generic;
using Others;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] private Animation anim;
    [SerializeField] private Score score;
    
    [SerializeField] private AudioClip sound;
    public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("CoinPopUp");
        score.AddScore(50);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.IsPlaying("CoinPopUp"))
            Destroy(gameObject);
    }

    public override void Init(AudioManager manager)
    {
        audioManager = manager;
        audioManager.PlaySound(sound);
    }
}
