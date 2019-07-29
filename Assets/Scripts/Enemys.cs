using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : DestroyedObj {

    // при уничтожения любого врага на его месте создается гриб и воспроизводится звук
    GameObject pfbMushroom;

    public override void Die()
    {
        base.Die();

        SoundManager.PlaySound("destroyTail");
        pfbMushroom = Resources.Load<GameObject>("Prefabs/mushroom");
         GameObject mush = Instantiate(pfbMushroom);
        mush.transform.position = transform.position;



    }
}
