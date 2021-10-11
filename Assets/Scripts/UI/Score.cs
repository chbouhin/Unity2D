using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] private TaskScore _taskScore;
    public int totalScore = 0;

    private void Start()
    {
        _textScore.text = "Score : " + totalScore.ToString("00000.##");
    }

    public void AddScore(int score)
    {
        totalScore += score;
        _textScore.text = "Score : " + totalScore.ToString("00000.##");
        _taskScore.ScoreChange(totalScore);
    }
}