using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskKillBowser : MonoBehaviour
{
    [SerializeField] private Text _textTask;
    [SerializeField] private ParticleSystem _explosion;

    public void KillBowser()
    {
        _textTask.color = Color.green;
        _explosion.Play();
    }
}