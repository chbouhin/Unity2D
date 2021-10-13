using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource music;
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        var sources = gameObject.GetComponents<AudioSource>();
        music = sources[0];
        sound = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        sound.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        music.PlayOneShot(clip);
    }
}
