using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextButtonOpt : MonoBehaviour
{
    [SerializeField] private KeyInput _keyInput;
    [SerializeField] private Text[] _texts;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Slider _musics;
    [SerializeField] private Slider _soundEffects;
    private Text _textSelect;
    private string _stringTextSave;

    public void InitOpt()
    {
        _musics.value = _keyInput.volumeMusics;
        _soundEffects.value = _keyInput.volumeSoundEffects;
        _texts[0].text = _keyInput.jump.ToString();
        _texts[1].text = _keyInput.left.ToString();
        _texts[2].text = _keyInput.right.ToString();
        _texts[3].text = _keyInput.pause.ToString();
    }

    private void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            Event evnt = Event.current;
            if (evnt.isKey && _textSelect) {
                _textSelect.text = evnt.keyCode.ToString();
                _textSelect = null;
            }
        }
    }

    public void OnPress(Text text)
    {
        DeleteTextSelect();
        _textSelect = text;
        _stringTextSave = _textSelect.text;
        _textSelect.text = "<>";
    }

    public void DeleteTextSelect()
    {
        if (_textSelect) {
            _textSelect.text = _stringTextSave;
            _textSelect = null;
        }
    }

    public void Save()
    {
        DeleteTextSelect();
        SaveObject saveObject = new SaveObject {
            volumeMusics = _musics.value,
            volumeSoundEffects = _soundEffects.value,
            jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), _texts[0].text),
            left = (KeyCode) System.Enum.Parse(typeof(KeyCode), _texts[1].text),
            right = (KeyCode) System.Enum.Parse(typeof(KeyCode), _texts[2].text),
            pause = (KeyCode) System.Enum.Parse(typeof(KeyCode), _texts[3].text),
        };
        File.WriteAllText(_keyInput.savePath, JsonUtility.ToJson(saveObject));
    }
}