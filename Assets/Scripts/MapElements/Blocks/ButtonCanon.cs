using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanon : MonoBehaviour
{
    [SerializeField] private Transform _canon;
    [SerializeField] private GameObject _bulletCanon;
    [SerializeField] private SpriteRenderer _sprite;
    private Color spriteColor;
    private float cooldownActivation = 10f;
    private float timerCooldownActivation = 0f;

    private void Start()
    {
        spriteColor = _sprite.color;
        _sprite.color = Color.red;
    }

    private void Update()
    {
        if (timerCooldownActivation < cooldownActivation) {
            timerCooldownActivation += Time.deltaTime;
            if (timerCooldownActivation >= cooldownActivation)
                _sprite.color = spriteColor;
        }
    }

    public void JumpOnButton()
    {
        if (timerCooldownActivation >= cooldownActivation) {
            timerCooldownActivation -= cooldownActivation;
            Instantiate(_bulletCanon, _canon.position, _bulletCanon.transform.rotation);
            _sprite.color = Color.red;
        }
    }
}