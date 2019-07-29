using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObj : MonoBehaviour {

    public int HP { get; set; }

   private GameObject pfbBooms;

    public virtual void Die() {
        pfbBooms = Resources.Load<GameObject>("Prefabs/bang");
        GameObject bang = Instantiate(pfbBooms);
        bang.transform.position = transform.position;
        Destroy(bang, 0.5f);
    }
}

