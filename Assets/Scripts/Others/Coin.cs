using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // [SerializeField] private Animation _anim;
    private Score _score;
    private AudioSource _audio;
    
    private void Start()
    {
        _score = GameObject.Find("Score").GetComponent<Score>();
        _audio = gameObject.GetComponent<AudioSource>();
        // _anim.Play("CoinPopUp");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            _score.AddScore(50);
            _audio.Play();
            Destroy(gameObject);
        }
    }
}
