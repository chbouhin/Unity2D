using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [HideInInspector] public string mySide;
    [HideInInspector] public int damage;
    private int moveSpeed = 10;
    private Vector3 directionVector;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetDirection(Vector3 position)
    {
        position.z = 0f;
        directionVector = (position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(directionVector * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(mySide)) {
            if (!col.gameObject.CompareTag("Wall"))
                col.gameObject.GetComponent<Armor>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}