using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void EscapeButton()
    {
        if (gameObject.activeSelf) {
            ContinueButton();
        } else {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ContinueButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}