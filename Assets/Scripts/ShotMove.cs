using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour {

	
	public float speed;
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up*Time.deltaTime*speed;
        Destroy(this.gameObject,3);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name!="Hero" && coll.gameObject.GetComponent<DestroyedObj>()!=null)
        {
            coll.gameObject.GetComponent<DestroyedObj>().HP--;
            Destroy(this.gameObject);
        }
      
    }
}
