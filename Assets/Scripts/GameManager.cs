using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float timer;

    private void Start()
    {
        _text.text = "Timer : " + timer;
    }

    private void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            _text.text = "Timer : " + FormatTime(timer);
            if (timer <= 0)
                _text.color = Color.red;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = (int) time / 60;
        int seconds = (int) Math.Ceiling(time - 60 * minutes);
        return string.Format("{0:00}.{1:00}", minutes, seconds);
    }
}