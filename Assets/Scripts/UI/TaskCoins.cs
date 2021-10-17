using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCoins : MonoBehaviour
{
    [SerializeField] private Text _textTask;
    [SerializeField] private ParticleSystem _explosion;
    private int coin = 0;

    public void AddCoin()
    {
        coin++;
        _textTask.text = "Get 10 coins (" + coin + "/10)";
        if (coin == 10) {
            _textTask.color = Color.green;
			_explosion.Play();
        }
    }
}