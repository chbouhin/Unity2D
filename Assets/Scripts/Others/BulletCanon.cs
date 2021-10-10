using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    private int moveSpeed = 5;

    private void Update()
    {
        transform.position -= transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("touch");
        if (col.gameObject.CompareTag("Enemy"))
            col.gameObject.GetComponent<Health>().TakeDamage();
        Destroy(gameObject);
    }
}