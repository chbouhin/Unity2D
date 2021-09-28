using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int damage;
    private Vector3 directionVector;
    private int moveSpeed = 10;

    private void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        directionVector = (mousePosition - transform.position).normalized;
        Destroy(gameObject, 3f); 
    }

    private void Update()
    {
        transform.Translate(directionVector * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) {
            if (col.gameObject.CompareTag("Enemy"))
                col.gameObject.GetComponent<EnemyManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
