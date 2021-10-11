using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskScore : MonoBehaviour
{
    [SerializeField] private Text _textTask;

    private void Start()
    {
        _textTask.text = "Get 5000 to score (0/5000)";
    }

    public void ScoreChange(int score)
    {
        _textTask.text = "Get 5000 to score (" + score + "/5000)";
        if (score >= 5000)
            _textTask.color = Color.green;
    }
}