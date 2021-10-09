using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Vector3 _directionVector;
    private int moveSpeed = 5;

    private void Start()
    {
        Destroy(gameObject, 3f);
        _directionVector = (GameObject.Find("Player").transform.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(_directionVector * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<Health>().TakeDamage();
            Destroy(gameObject);
        } else if (!col.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}