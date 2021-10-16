using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private AudioClip _stageMusic;
    private AudioManager _audioManager;
    
    [SerializeField] private KeyInput _keyInput;
    [SerializeField] private Score _score;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _continue;
    [SerializeField] private Pause _pause;
    [SerializeField] private Text _textTaskFinishGame;
    [SerializeField] private Text _textUIPause;

    private void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        _audioManager.PlayMusic(_stageMusic);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyInput.pause))
            _pause.EscapeButton(_audioManager);
    }


    public void LooseGame()
    {
        Time.timeScale = 0f;
        _textUIPause.text = "Defeat";
        _textUIPause.color = Color.red;
        _pause.gameObject.SetActive(true);
        _continue.interactable = false;
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        _textUIPause.text = "Victory";
        _textUIPause.color = Color.green;
        _continue.interactable = false;
        _score.AddScore((int) (_timer.timer * 10));
        _pause.gameObject.SetActive(true);
        _textTaskFinishGame.color = Color.green;
    }
}