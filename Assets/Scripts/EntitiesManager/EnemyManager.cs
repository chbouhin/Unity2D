using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    [SerializeField] private int moveSpeed = 3;
    private bool goToRight = false;

    private void Update()
    {
        if (goToRight)
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        else
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }

    public void ChangeDirection()
    {
        goToRight = !goToRight;
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player")) {
            col.gameObject.GetComponent<Health>().TakeDamage();
        }
    }
}