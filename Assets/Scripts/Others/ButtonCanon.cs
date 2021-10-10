using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanon : MonoBehaviour
{
    [SerializeField] private Transform _canon;
    [SerializeField] private GameObject _bulletCanon;
    private float cooldownActivation = 15f;
    private float timerCooldownActivation = 0f;

    private void Update()
    {
        if (timerCooldownActivation < cooldownActivation)
            timerCooldownActivation += Time.deltaTime;
    }

    public void JumpOnButton()
    {
        // if (timerCooldownActivation >= cooldownActivation) {
            timerCooldownActivation -= cooldownActivation;
            Instantiate(_bulletCanon, _canon.position, Quaternion.identity);
        // }
    }
}