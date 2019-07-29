using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// класс для объектов, которые могут быть уничтожены
public class DestroyedObj : MonoBehaviour {

    //  у каждого объекта есть жизни
    public int HP { get; set; }

   private GameObject pfbBooms;
    // при уничтожении воспроизводим взрыв
    public virtual void Die() {
        pfbBooms = Resources.Load<GameObject>("Prefabs/bang");
        GameObject bang = Instantiate(pfbBooms);
        bang.transform.position = transform.position;
        Destroy(bang, 0.5f);
    }
}

