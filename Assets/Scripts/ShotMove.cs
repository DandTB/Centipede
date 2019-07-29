using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour {

    // скорость выстрела
    public float speed;

    // двигаем пулю. если попаданий 0, то удаляем пулю
    void Update () {
        transform.position += Vector3.up*Time.deltaTime*speed;
        Destroy(this.gameObject,3);

	}
    // если есть попадание, то отнимаем 1 жизнь и уничтожаемся 
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name!="Hero" && coll.gameObject.GetComponent<DestroyedObj>()!=null)
        {
            coll.gameObject.GetComponent<DestroyedObj>().HP--;
            Destroy(this.gameObject);
        }
      
    }
}
