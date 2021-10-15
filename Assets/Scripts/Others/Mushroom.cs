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
    private bool goToRight;
    private Vector3 _scale;
    
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _audio = gameObject.GetComponent<AudioSource>();
        _anim.Play("MushroomPopUp");
        _audio.PlayOneShot(_audioPopUp);
        goToRight = Random.Range(0, 2) == 0;
        _scale = transform.localScale;
    }

    private void Update()
    {
        if (!_anim.IsPlaying("MushroomPopUp")) {
            gameObject.GetComponent<Animator>().enabled = false;
            if (goToRight) {
                transform.position += transform.right * moveSpeed * Time.deltaTime;
                if (_scale.x < 1) {
                    _scale.x += Time.deltaTime * 8;
                    if (_scale.x > 1)
                        _scale.x = 1;
                    transform.localScale = _scale;
                }
            } else {
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
                if (_scale.x > -1) {
                    _scale.x -= Time.deltaTime * 8;
                    if (_scale.x < -1)
                        _scale.x = -1;
                    transform.localScale = _scale;
                }
            }
        }
    }

    public void ChangeDirection()
    {
        goToRight = !goToRight;
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
