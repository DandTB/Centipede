using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : Enemys {

    public float speed;
    Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = Vector2.down;
        HP = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (transform.position.y >= -20) {
            direction = Vector2.down;
        }
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (HP < 1) {
            Die();
            GameLogic.Instance.Score += 300;
            Destroy(this.gameObject);
        }

        if (coll.gameObject.GetComponent<Hero>()!= null) {
            coll.gameObject.GetComponent<Hero>().Die();
        }

        if (coll.gameObject.GetComponent<Mushroom>() != null) {
            int rand = Random.Range(0,1);
            if (rand == 0) {
                GameLogic.Instance.countMushromms--;
                Destroy(coll.gameObject);
            }
        }

        if (direction == Vector2.down)
        {
            direction = Vector2.up + Vector2.right;
        }
        else if (direction == Vector2.up + Vector2.right)
        {
            direction = Vector2.down + Vector2.left;
        }
        else if (direction == Vector2.down + Vector2.left) {
            direction = Vector2.up + Vector2.left;
        }
        else if (direction == Vector2.up + Vector2.left) {
            direction=Vector2.down;        }
    }
}
