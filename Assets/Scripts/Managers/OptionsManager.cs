using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _options;
    [SerializeField] private TextButtonOpt _textButtonOpt;
    [SerializeField] private KeyInput _keyInput;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _optionsMusic;

    public void ShowOptions()
    {
        _textButtonOpt.InitOpt();
        _UI.SetActive(false);
        _options.SetActive(true);
        if (_optionsMusic)
            _audioManager.PlayMusicOptions(_optionsMusic);
    }

    public void HideOptions()
    {
        _keyInput.Load();
        _textButtonOpt.DeleteTextSelect();
        _UI.SetActive(true);
        _options.SetActive(false);
        if (_optionsMusic)
            _audioManager.StopMusicOptions();
        _audioManager.SetVolumeMusics(_keyInput.volumeMusics);
        _audioManager.SetVolumeSoundEffects(_keyInput.volumeSoundEffects);
    }
}
