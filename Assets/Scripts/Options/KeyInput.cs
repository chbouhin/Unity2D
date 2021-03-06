using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyInput : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SceneUpdate _sceneUpdate;
    [HideInInspector] public string savePath;
    [HideInInspector] public float volumeMusics;
    [HideInInspector] public float volumeSoundEffects;
    [HideInInspector] public KeyCode jump;
    [HideInInspector] public KeyCode left;
    [HideInInspector] public KeyCode right;
    [HideInInspector] public KeyCode pause;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/save.txt";
        Load();
    }

    public void Load()
    {
        if (!File.Exists(savePath))
            CreateNewSave();
        if (File.Exists(savePath)) {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(File.ReadAllText(savePath));
            volumeMusics = saveObject.volumeMusics;
            volumeSoundEffects = saveObject.volumeSoundEffects;
            _audioManager.SetVolumeMusics(volumeMusics);
            _audioManager.SetVolumeSoundEffects(volumeSoundEffects);
            jump = saveObject.jump;
            left = saveObject.left;
            right = saveObject.right;
            pause = saveObject.pause;
        } else {
            _sceneUpdate.QuitGame();
        }
    }

    private void CreateNewSave()
    {
        SaveObject saveObject = new SaveObject {
            volumeMusics = 0.5f,
            volumeSoundEffects = 0.5f,
            jump = KeyCode.Z,
            left = KeyCode.Q,
            right = KeyCode.D,
            pause = KeyCode.Escape,
        };
        File.WriteAllText(savePath, JsonUtility.ToJson(saveObject));
    }
}

public class SaveObject
{
    public float volumeMusics;
    public float volumeSoundEffects;
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
    public KeyCode pause;
}