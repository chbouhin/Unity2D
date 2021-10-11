using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    private float moveSpeed = 7f;

    private void Update()
    {
        transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            col.gameObject.GetComponent<Health>().TakeDamage();
        Destroy(gameObject);
    }
}