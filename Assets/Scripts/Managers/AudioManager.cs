using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _music;
    private AudioSource _sound;
    private AudioSource _optionsMusic;

    private void Awake()
    {
        AudioSource[] sources = gameObject.GetComponents<AudioSource>();
        _music = sources[0];
        _sound = sources[1];
        _optionsMusic = sources[2];
    }

    public void PlaySound(AudioClip clip)
    {
        _sound.PlayOneShot(clip);
    }

    public void PlayMusicOptions(AudioClip clip)
    {
        _optionsMusic.PlayOneShot(clip);
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

    public void RestartMusic()
    {
        _music.Play();
    }

    public void StopMusicOptions()
    {
        _optionsMusic.Stop();
    }

    public void StopMusic()
    {
        _music.Stop();
    }

    public void PlayDelayedMusic(AudioClip clip, float delay)
    {
        _music.clip = clip;
        _music.PlayDelayed(delay);
    }

    public void SetVolumeMusics(float value)
    {
        _music.volume = value;
        _optionsMusic.volume = value;
    }

    public void SetVolumeSoundEffects(float value)
    {
        _sound.volume = value;
    }
}
