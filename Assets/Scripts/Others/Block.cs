using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerObject;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip breakSound;
    private AudioManager audioManager;
    
    [SerializeField] private bool destroyable;
    
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
