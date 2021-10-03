using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private float moveSpeed = 8f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _weapon.CanAttack())
            _weapon.Attack(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime);
    }
}