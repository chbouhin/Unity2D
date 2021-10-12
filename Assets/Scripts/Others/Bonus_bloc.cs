using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_bloc : MonoBehaviour
{
    [SerializeField] private GameObject bonusItem;
    [SerializeField] private Sprite usedSprite;
    private bool used = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()//TEMPORAIRE
    {
        gameObject.GetComponent<Bonus_bloc>().Activate();
    }
    
    public void Activate()
    {
        var parent = gameObject.transform;

        if (used)
            return;
        var item = Instantiate(bonusItem);
        item.transform.parent = parent;
        item.transform.position = parent.position + new Vector3(0, 0, 1);
        used = true;

        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = usedSprite;
    }
}
