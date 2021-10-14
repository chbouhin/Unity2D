using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private Animation anim;
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] AudioClip audioPopUp;
    [SerializeField] AudioClip audioUse;
    private AudioSource audio;
    private int direction;
    
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        anim.Play("MushroomPopUp");
        audio.PlayOneShot(audioPopUp);
        direction = Random.Range(1, 3);
    }

    private void Update()
    {
        if (!anim.IsPlaying("MushroomPopUp")) {
            gameObject.GetComponent<Animator>().enabled = false;
            if (direction == 1)
                transform.position += transform.right * moveSpeed * Time.deltaTime;
            else
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            player.GetBonus();
            audio.PlayOneShot(audioUse);
            Destroy(gameObject);
        } else if (col.transform.CompareTag("Wall")) {
            direction = direction == 1 ? 2 : 1;
        }
    }
}
