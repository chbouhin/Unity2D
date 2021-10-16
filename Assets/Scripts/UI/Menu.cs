using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _audioManagerObject;
    [SerializeField] private AudioClip _menuMusic;
    private AudioManager _audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
        _audioManager.PlayMusic(_menuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
