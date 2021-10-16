using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCoins : MonoBehaviour
{
    [SerializeField] private Text _textTask;
    [SerializeField] private ParticleSystem _explosion;
    private int coin = 0;

    private void Start()
    {
        _textTask.text = "Get 5 coins (0/5)";
    }

    public void AddCoin()
    {
        coin++;
        _textTask.text = "Get 5 coins (" + coin + "/5)";
        if (coin == 5) {
            _textTask.color = Color.green;
			_explosion.Play();
        }
    }
}