using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    [SerializeField] private Transform _colWall;
    [SerializeField] private int moveSpeed = 3;
    private bool goToRight = true;

    private void Update()
    {
        if (Physics2D.OverlapBox(_colWall.position, _colWall.localScale, 0, LayerMask.GetMask("Wall"))) {
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
        Gizmos.DrawCube(_colWall.position, _colWall.localScale);
    }
}