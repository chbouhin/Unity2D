using System.Collections;
using System.Collections.Generic;
using Others;
using UnityEngine;

public class Mushroom : Item
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private Animation anim;
    [SerializeField] private int moveSpeed = 3;
    private int direction;
    
    [SerializeField] private AudioClip popUpSound;
    [SerializeField] private AudioClip useSound;
    public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("MushroomPopUp");
        direction = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.IsPlaying("MushroomPopUp"))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            if (direction == 1)
                transform.position += transform.right * moveSpeed * Time.deltaTime;
            else
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }

    public override void Init(AudioManager manager)
    {
        audioManager = manager;
        audioManager.PlaySound(popUpSound);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            player.GetBonus();
            audioManager.PlaySound(useSound);
            Destroy(gameObject);
        } else if (col.transform.CompareTag("Wall"))
        {
            direction = direction == 1 ? 2 : 1;
        }
    }
}
