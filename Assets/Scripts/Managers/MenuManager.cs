using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private AudioClip _menuMusic;
    private AudioManager _audioManager;
    
    private void Start()
    {
        Time.timeScale = 1f;
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        _audioManager.PlayMusic(_menuMusic, true);
    }
}
