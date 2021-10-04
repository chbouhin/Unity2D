using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    [SerializeField] private Transform _colWall;
    private bool goToRight = true;
    private int moveSpeed = 3;

    private void Update()
    {
        if (Physics2D.OverlapCircle(_colWall.position, 0.25f, LayerMask.GetMask("Wall"))) {
            goToRight = !goToRight;
            Vector3 scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
        if (goToRight)
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        else
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }

    private void OnDrawGizmos()//TEMPORAIRE
    {
        Gizmos.DrawWireSphere(_colWall.position, 0.25f);
    }
}