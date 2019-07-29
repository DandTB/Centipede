using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : Enemys {

    public float speed;
    Vector2 tempPosition;
    bool goCreate;
	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down*speed*Time.deltaTime;

        if (tempPosition.y - transform.position.y > 2) {
            tempPosition = transform.position;
            if (goCreate)
            {
                GameLogic.Instance.CreateMushroom(transform.position);
                goCreate = false;
            }
        }
        if (transform.position.y < -30) {
            Destroy(this.gameObject);
        }

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<ShotMove>() != null) {
            GameLogic.Instance.Score += 300;
            Die();
            Destroy(this.gameObject);
        }
        if (col.gameObject.GetComponent<Hero>() != null) {
            col.gameObject.GetComponent<Hero>().Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
           goCreate = true;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        goCreate = false;

    }


}
