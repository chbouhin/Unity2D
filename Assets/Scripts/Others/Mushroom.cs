using System.Collections;
using System.Collections.Generic;
using Others;
using UnityEngine;

public class Mushroom : Item
{
    [SerializeField] private Animation _anim;
    [SerializeField] private int _moveSpeed = 3;
    private Vector3 _scale;
    private bool _goToRight;

    [SerializeField] AudioClip _audioPopUp;
    [SerializeField] AudioClip _audioUse;
    private AudioManager _audioManager;

    private PlayerHealth _player;
    
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _anim.Play("MushroomPopUp");
        _goToRight = Random.Range(0, 2) == 0;
        _scale = transform.localScale;
    }

    private void Update()
    {
        if (!_anim.IsPlaying("MushroomPopUp")) {
            gameObject.GetComponent<Animator>().enabled = false;
            if (_goToRight) {
                transform.position += transform.right * _moveSpeed * Time.deltaTime;
                if (_scale.x < 1) {
                    _scale.x += Time.deltaTime * 8;
                    if (_scale.x > 1)
                        _scale.x = 1;
                    transform.localScale = _scale;
                }
            } else {
                transform.position -= transform.right * _moveSpeed * Time.deltaTime;
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
        _goToRight = !_goToRight;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(_player);
        if (col.gameObject.CompareTag("Player")) {
            _player.GetBonus();
            _audioManager.PlaySound(_audioUse);
            Destroy(gameObject);
        }
    }

    public override void Init(AudioManager manager)
    {
        _audioManager = manager;
        _audioManager.PlaySound(_audioPopUp);
    }
}
