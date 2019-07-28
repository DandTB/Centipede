using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCentipede: DestroyedObj {


   
    public float speed;

    //Vector2 start_pos;
    Vector2 direction;
    Vector2 temp_direction;
   
    float myTimer;

    void Start() {
        HP = 1;
        direction = Vector2.down;
        temp_direction = direction;
    }

    private void Update()
    {
        transform.right = direction;
        transform.position += new Vector3( direction.x,direction.y,0) * speed * Time.deltaTime;



        if (direction == Vector2.down)
        {
            
            myTimer += Time.deltaTime;
            if (myTimer > 0.1f)
            {
                if (temp_direction == Vector2.down) {
                    direction = Vector2.right;
                }
                else if (temp_direction == Vector2.left)
                {
                    direction = Vector2.right;
                   
                }else if (temp_direction == Vector2.right)
                {
                    direction = Vector2.left;
                    
                }
               
                myTimer = 0;
            }
            
        }
        if (HP < 1) {
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
    }

 
    



}
