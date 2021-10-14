using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private Animation _anim;
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] AudioClip _audioPopUp;
    [SerializeField] AudioClip _audioUse;
    private PlayerHealth _player;
    private AudioSource _audio;
    private int direction;
    
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _audio = gameObject.GetComponent<AudioSource>();
        _anim.Play("MushroomPopUp");
        _audio.PlayOneShot(_audioPopUp);
        direction = Random.Range(1, 3);
    }

    private void Update()
    {
        if (!_anim.IsPlaying("MushroomPopUp")) {
            gameObject.GetComponent<Animator>().enabled = false;
            if (direction == 1)
                transform.position += transform.right * moveSpeed * Time.deltaTime;
            else
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }

    public void ChangeDirection()
    {
        direction = direction == 1 ? 2 : 1;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            _player.GetBonus();
            _audio.PlayOneShot(_audioUse);
            Destroy(gameObject);
        }
    }
}
