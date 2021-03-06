using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private AudioClip _stageMusic;
    [SerializeField] private AudioClip _winMusic;
    [SerializeField] private AudioClip _looseMusic;
    private AudioManager _audioManager;
    
    [SerializeField] private KeyInput _keyInput;
    [SerializeField] private Score _score;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _continue;
    [SerializeField] private PauseManager _pause;
    [SerializeField] private Text _textUIPause;
    private bool inGame = true;

    private void Start()
    {
        Time.timeScale = 1f;
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        _audioManager.PlayMusic(_stageMusic, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyInput.pause) && inGame)
            _pause.EscapeButton(_audioManager);
    }

    public void LooseGame()
    {
        _audioManager.StopMusic();
        _audioManager.PlayMusic(_looseMusic);
        Time.timeScale = 0f;
        _textUIPause.text = "Defeat";
        _textUIPause.color = Color.red;
        _pause.gameObject.SetActive(true);
        _continue.interactable = false;
        inGame = false;
    }

    public void WinGame()
    {
        _audioManager.StopMusic();
        _audioManager.PlayMusic(_winMusic);
        Time.timeScale = 0f;
        _textUIPause.text = "Victory";
        _textUIPause.color = Color.green;
        _continue.interactable = false;
        _score.AddScore((int) (_timer.timer * 10));
        _pause.gameObject.SetActive(true);
        inGame = false;
    }
}