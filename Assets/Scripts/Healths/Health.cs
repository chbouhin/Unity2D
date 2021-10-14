using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    private float invicibleTime = 3f;
    protected float TimerInvicibleTime;
    private float spriteFlashing = 0.1f;
    private float TimerSpriteFlashing = 0f;

    public abstract void TakeDamage();

    public abstract void Die();

    protected void Start()
    {
        TimerInvicibleTime = invicibleTime;
    }

    private void Update()   
    {
        if (TimerInvicibleTime < invicibleTime) {
            TimerInvicibleTime += Time.deltaTime;
            if (TimerSpriteFlashing < spriteFlashing) {
                TimerSpriteFlashing += Time.deltaTime;
            } else {
                TimerSpriteFlashing = 0f;
                _spriteRenderer.enabled = !_spriteRenderer.enabled;
            }
            if (TimerInvicibleTime >= invicibleTime && _spriteRenderer.enabled == false)
                _spriteRenderer.enabled = true;
        }
    }

    public bool IsInvicible()
    {
        return TimerInvicibleTime >= invicibleTime;
    }
}