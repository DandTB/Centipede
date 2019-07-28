using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : DestroyedObj {

    GameObject pfbBooms;
    GameObject pfbMushroom;


    public override void Die()
    {
        base.Die();
        pfbBooms = Resources.Load<GameObject>("Prefabs/bang");
        GameObject bang = Instantiate(pfbBooms);
        bang.transform.position = transform.position;
        Destroy(bang,0.5f);

    }
}
