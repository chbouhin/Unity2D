using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private int damage = 8;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<BulletManager>().damage = damage;
    }
}
