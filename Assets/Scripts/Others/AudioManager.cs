using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _music;
    private AudioSource _sound;
    
    private void Start()
    {
        AudioSource[] sources = gameObject.GetComponents<AudioSource>();
        _music = sources[0];
        _sound = sources[1];
    }

    public void PlaySound(AudioClip clip)
    {
        _sound.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        _music.PlayOneShot(clip);
    }

    public void PauseMusic()
    {
        _music.Pause();
    }

    public void ResumeMusic()
    {
        _music.UnPause();
    }
}
