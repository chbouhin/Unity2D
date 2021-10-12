using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyInput : MonoBehaviour
{
    [HideInInspector] public string savePath;
    [HideInInspector] public KeyCode jump;
    [HideInInspector] public KeyCode left;
    [HideInInspector] public KeyCode right;
    [HideInInspector] public KeyCode pause;

    private void Awake()
    {
        savePath = Application.dataPath + "/save.txt";
        Load();
    }

    private void Load()
    {
        if (File.Exists(savePath)) {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(File.ReadAllText(savePath));
            jump = saveObject.jump;
            left = saveObject.left;
            right = saveObject.right;
            pause = saveObject.pause;
        }
    }
}

public class SaveObject
{
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
    public KeyCode pause;
}