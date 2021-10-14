using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHitBox : MonoBehaviour
{
    [SerializeField] private Mushroom _mushroom;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Wall"))
            _mushroom.ChangeDirection();
    }
}