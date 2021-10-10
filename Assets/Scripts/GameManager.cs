using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _continue;
    [SerializeField] private Pause _pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _pause.EscapeButton();
    }


    public void LooseGame()
    {
        _timer.gameObject.SetActive(false);
        _pause.gameObject.SetActive(true);
        _continue.interactable = false;
    }

    public void WinGame()
    {
        _continue.interactable = false;
        _timer.gameObject.SetActive(false);
        _score.AddScore((int) (_timer.timer * 10));
        _pause.gameObject.SetActive(true);
    }
}