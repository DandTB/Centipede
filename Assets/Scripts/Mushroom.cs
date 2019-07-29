using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : DestroyedObj {

   public  Sprite[] mushroom_sprites;
    

    // Use this for initialization
    void Awake () {
        HP = 4;

        
	}
    private void Start()
    {
        if (transform.position.y < -20)
        {
            GameLogic.Instance.countMushromms++;
        }
    }

    // Update is called once per frame
    void Update () {
        if (HP == 3)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[0];
        }
        if (HP == 2)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[1];
        }
        if (HP == 1)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[2];
        }
        if (HP < 1)
        {
            GameLogic.Instance.Score += 1;
            GameLogic.Instance.speedCentipede -= 0.1f;
          
            Destroy(this.gameObject);
            if (transform.position.y < -20)
            { 
                GameLogic.Instance.countMushromms-=1;
            }
        }
    }
}
