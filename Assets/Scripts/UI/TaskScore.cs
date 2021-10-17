using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskScore : MonoBehaviour
{
    [SerializeField] private Text _textTask;
    [SerializeField] private ParticleSystem _explosion;
    private bool isFinish = false;

    public void ScoreChange(int score)
    {
        _textTask.text = "Get 3000 to score (" + score + "/3000)";
        if (score >= 3000) {
            if (!isFinish) {
                _textTask.color = Color.green;
                _explosion.Play();
            }
            isFinish = true;
        }
    }
}