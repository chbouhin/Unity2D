using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private Score _score;
    
    [SerializeField] private GameObject audioManagerObject;
    [SerializeField] private AudioClip coinSound;
    private AudioManager audioManager;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
            audioManager.PlaySound(coinSound);
            _score.AddScore(50);
            Destroy(gameObject);
        }
    }
}