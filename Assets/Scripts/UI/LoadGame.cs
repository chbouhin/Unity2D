using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
