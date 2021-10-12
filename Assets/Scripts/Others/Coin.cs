using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private Score score;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("CoinPopUp");
        score.AddScore(50);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.IsPlaying("CoinPopUp"))
            Destroy(gameObject);
    }
}
