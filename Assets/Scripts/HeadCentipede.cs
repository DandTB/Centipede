using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCentipede: Enemys {


   
    float speed;
    //public bool haveTail;

    Vector2 startPosicition;
    Vector2 direction;
    Vector2 temp_direction;
    Vector3 tempPosition;
  

    void Start() {
        HP = 1;
        direction = Vector2.down;
        temp_direction = direction;
        tempPosition = transform.position;
        speed = GameLogic.Instance.speedCentipede;
    }

    private void Update()
    {
        transform.right = -direction;
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;


        if (direction == Vector2.down)
        {


            if ((tempPosition.y - transform.position.y) >= 1)
            {
                tempPosition = transform.position;
                if (temp_direction == Vector2.down)
                {
                    direction = Vector2.right;
                }
                else if (temp_direction == Vector2.left)
                {
                    direction = Vector2.right;

                }
                else if (temp_direction == Vector2.right)
                {
                    direction = Vector2.left;

                }


            }

        }
     
        if (HP < 1)
        {
            Die();
            GameLogic.Instance.Score += 100;
            Destroy(transform.parent.gameObject);
        }

    }
    

    private void OnCollisionEnter2D (Collision2D col)
    {
        temp_direction = direction;
        if (col.gameObject.tag == "wall")
        {
            if (direction == Vector2.right)
            {

                direction = Vector2.down;
            }
            else if (direction == Vector2.down)
            {
                direction = Vector2.left;
            }
            else if (direction == Vector2.left)
            {
                direction = Vector2.down;
            }
        }
        if (col.gameObject.GetComponent<Hero>() != null) {
            Die();
            col.gameObject.GetComponent<Hero>().Die();
            Destroy(transform.parent.gameObject);
        }
        if (col.gameObject.name == "bottom") {
            GameLogic.Instance.GameOver();
        }
    }

 
    



}
