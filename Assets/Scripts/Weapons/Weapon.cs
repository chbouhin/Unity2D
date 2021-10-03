using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Slider _cooldownSlider;
    [HideInInspector] public float range;
    protected int damage;
    protected float cooldown;
    private float timerCooldown = 0f;

    protected virtual void Start()
    {
        _cooldownSlider.maxValue = cooldown;
        _cooldownSlider.value = timerCooldown;
    }

    private void Update()
    {
        if (timerCooldown < cooldown) {
            timerCooldown += Time.deltaTime;
            _cooldownSlider.value = timerCooldown;
        }
    }

    protected virtual void ResetCooldown()
    {
        timerCooldown = 0;
        _cooldownSlider.value = timerCooldown;
    }

    public abstract void Attack(Vector3 direction);

    public bool CanAttack()
    {
        return timerCooldown >= cooldown;
    }
}