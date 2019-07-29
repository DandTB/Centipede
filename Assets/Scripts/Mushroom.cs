using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : DestroyedObj {

   public  Sprite[] mushroom_sprites;
    

    // Use this for initialization
    void Awake () {
        HP = 4;
        
        
	}
  
	// Update is called once per frame
	void Update () {
        if (HP == 3) {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[0];
        }
        else if (HP == 2)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[1];
        }
        else if (HP == 1)
        {
            GetComponent<SpriteRenderer>().sprite = mushroom_sprites[2];
        }
        else if (HP<1)
        {
            GameLogic.Instance.Score += 1;
            Destroy(this.gameObject);
        }
    }
}
