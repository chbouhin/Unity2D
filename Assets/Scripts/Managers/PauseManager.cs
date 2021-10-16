using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private AudioClip _pauseSound;
    private AudioManager _audioManager;
    
    public void EscapeButton(AudioManager manager)
    {
        _audioManager = manager;
        if (gameObject.activeSelf) {
            ContinueButton();
        } else {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            _audioManager.PauseMusic();
            _audioManager.PlaySound(_pauseSound);
        }
    }

    public void ContinueButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        _audioManager.ResumeMusic();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}