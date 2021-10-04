using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Text _textTimer;
    [SerializeField] private float timer;

    private void Start()
    {
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
    }

    private string FormatTime(float time)
    {
        int minutes = (int) time / 60;
        int seconds = (int) Math.Ceiling(time - 60 * minutes);
        return string.Format("{0:00}.{1:00}", minutes, seconds);
    }
}