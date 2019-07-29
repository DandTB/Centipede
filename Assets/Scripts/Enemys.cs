using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : DestroyedObj {

   
    GameObject pfbMushroom;


    public override void Die()
    {
        base.Die();

       
        pfbMushroom = Resources.Load<GameObject>("Prefabs/mushroom");
         GameObject mush = Instantiate(pfbMushroom);
        mush.transform.position = transform.position;



    }
}
