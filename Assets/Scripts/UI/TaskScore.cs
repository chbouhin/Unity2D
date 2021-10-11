using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskScore : MonoBehaviour
{
    [SerializeField] private Text _textTask;

    private void Start()
    {
        _textTask.text = "Get 1000 to score (0/1000)";
    }

    public void ScoreChange(int score)
    {
        _textTask.text = "Get 1000 to score (" + score + "/1000)";
        if (score >= 1000)
            _textTask.color = Color.green;
    }
}