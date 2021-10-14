using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerObject;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private bool destroyable;
    private AudioManager audioManager;    
    
    private void Start()
    {
        audioManager = audioManagerObject.GetComponent<AudioManager>();
    }

    private void OnMouseDown()//TEMPORAIRE
    {
        gameObject.GetComponent<Block>().Activate();
    }

    public void Activate()
    {
        if (destroyable)
        {
            audioManager.PlaySound(breakSound);
            Destroy(gameObject);
            return;
        }
        audioManager.PlaySound(hitSound);
    }
}
