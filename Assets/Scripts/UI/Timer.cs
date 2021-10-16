using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Text _textTimer;
    [SerializeField] private AudioClip _hurryMusic;
    [SerializeField] private AudioClip _hurrySound;
    private AudioManager _audioManager;
    public float timer;
    private bool _hurry = false;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _textTimer.text = "Timer : " + timer;
    }

    private void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            _textTimer.text = "Timer : " + FormatTime(timer);
            if (timer <= 0)
                _textTimer.color = Color.red;
        } else
            _playerHealth.Die();

        if (timer < 40 && !_hurry)
        {
            _hurry = true;
            _audioManager.StopMusic();
            _audioManager.PlaySound(_hurrySound);
            _audioManager.PlayDelayedMusic(_hurryMusic, _hurrySound.length);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = (int) time / 60;
        int seconds = (int) Math.Ceiling(time - 60 * minutes);
        return string.Format("{0:00}.{1:00}", minutes, seconds);
    }
}