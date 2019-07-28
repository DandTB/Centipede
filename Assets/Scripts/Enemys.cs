using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : DestroyedObj {

    GameObject pfbBooms;
    GameObject pfbMushroom;


    public override void Die()
    {
        base.Die();

        //create bang
        pfbBooms = Resources.Load<GameObject>("Prefabs/bang");
        GameObject bang = Instantiate(pfbBooms);
        bang.transform.position = transform.position;
        Destroy(bang,0.5f);

        //create mushroom
        pfbMushroom = Resources.Load<GameObject>("Prefabs/mushroom");
         GameObject mush = Instantiate(pfbMushroom);
        mush.transform.position = transform.position;



    }
}
